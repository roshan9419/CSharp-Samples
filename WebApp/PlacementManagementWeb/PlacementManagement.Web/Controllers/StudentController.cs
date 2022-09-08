using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PlacementManagement.Models;
using PlacementManagement.Web.Models;
using PlacementManagement.Web.Repository;
using PlacementManagement.Web.Utils;
using PlacementManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly IStudentRepository _studentRepo;
        private readonly IStudentAcademicRepository<StudentProgram, Program> _studentProgramRepo;
        private readonly IStudentAcademicRepository<StudentQualification, QualificationType> _studentQualRepo;
        private readonly IStudentAcademicRepository<StudentSkill, Skill> _studentSkillRepo;

        public StudentController(
            IStudentRepository studentRepo, 
            IStudentAcademicRepository<StudentProgram, Program> studentProgramRepo,
            IStudentAcademicRepository<StudentQualification, QualificationType> studentQualRepo,
            IStudentAcademicRepository<StudentSkill, Skill> studentSkillRepo)
        {
            _studentRepo = studentRepo;
            _studentProgramRepo = studentProgramRepo;
            _studentQualRepo = studentQualRepo;
            _studentSkillRepo = studentSkillRepo;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                return _userManager;
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Student
        public async Task<ActionResult> Index(int page = 1, int limit = 10)
        {
            var students = await _studentRepo.GetAllStudents(page, limit);
            var studentVMList = new List<StudentDetailViewModel>();
            
            foreach (var student in students)
                studentVMList.Add(new StudentDetailViewModel { Student = student });

            if (students.Count == limit)
                ViewBag.NextPage = page + 1;

            if (page > 1)
                ViewBag.PrevPage = page - 1;

            return View(studentVMList);
        }

        // GET: Student/Details
        // GET: Student/Details?studentId=3
        public async Task<ActionResult> Details(int? studentId = null)
        {
            if (studentId == null)
                return View();

            try
            {
                var student = await _studentRepo.GetStudent((int)studentId);
                var programs = await _studentProgramRepo.GetAll((int)studentId);
                var qualifications = await _studentQualRepo.GetAll((int)studentId);
                var skills = await _studentSkillRepo.GetAll((int)studentId);

                var studentDetail = new StudentDetailViewModel
                {
                    Student = student,
                    StudentPrograms = programs,
                    StudentQualifications = qualifications,
                    StudentSkills = skills
                };

                return View(studentDetail);
            }
            catch
            {
                ViewBag.ErrorMessage = "No such student exists - " + studentId.ToString();
                return View();
            }
        }

        // GET: Student/Create
        public ActionResult Register()
        {
            ViewBag.States = new SelectList(SelectListItemHelper.GetIndianStates(), "Value", "Text");
            return View();
        }

        // POST: Student/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(StudentRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

                var student = new Student
                {
                    UserId = user.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    RegistrationDate = DateTime.Now,
                    Aadhaar = model.Aadhaar,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    PostalCode = model.PostalCode,
                    State = model.State
                };

                // Create user account
                string password = GeneratePassword(student);
                var result = await UserManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // Assign student role
                    await UserManager.AddToRoleAsync(user.Id, "Student");

                    // Create Student
                    await _studentRepo.CreateStudent(student);

                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: Student/Update/5
        public async Task<ActionResult> Update(int? studentId = null)
        {
            if (studentId == null)
                return View();

            try
            {
                var student = await _studentRepo.GetStudent((int)studentId);
                var model = new StudentRegisterViewModel
                {
                    StudentId = (int)studentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Gender = student.Gender,
                    DateOfBirth = student.DateOfBirth,
                    Aadhaar = student.Aadhaar,
                    PhoneNumber = student.PhoneNumber,
                    Address = student.Address,
                    Country = student.Country,
                    City = student.City,
                    State = student.State,
                    PostalCode = student.PostalCode
                };
                ViewBag.States = new SelectList(SelectListItemHelper.GetIndianStates(), "Value", "Text", model.State);
                return View(model);
            }
            catch
            {
                ViewBag.ErrorMessage = "No such student exists - " + studentId.ToString();
                return View();
            }
        }

        // POST: Student/Update/5
        [HttpPost]
        public async Task<ActionResult> Update(int studentId, StudentRegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = await _studentRepo.GetStudent(studentId);
                    student = new Student
                    {
                        UserId = student.UserId,
                        StudentId = student.StudentId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        RegistrationDate = DateTime.Now,
                        Aadhaar = model.Aadhaar,
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country,
                        DateOfBirth = model.DateOfBirth,
                        Gender = model.Gender,
                        PhoneNumber = model.PhoneNumber,
                        PostalCode = model.PostalCode,
                        State = model.State
                    };

                    await _studentRepo.UpdateStudent(studentId, student);
                }
                return RedirectToAction("Details", new { studentId = studentId });
            }
            catch
            {
                ViewBag.ErrorMessage = "No such student exists - " + studentId.ToString();
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int studentId)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int studentId, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private string GeneratePassword(Student student)
        {
            return "123456";
        }
    }
}
