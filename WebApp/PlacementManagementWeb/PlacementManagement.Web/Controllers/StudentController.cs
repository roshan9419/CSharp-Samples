using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PlacementManagement.Models;
using PlacementManagement.Web.Models;
using PlacementManagement.Web.Repository;
using PlacementManagement.Web.Utils;
using PlacementManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Fetches the students page wise and loads the list page
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="limit">Per page limit</param>
        public async Task<ActionResult> Index(int page = 1, int limit = 10)
        {
            var studentVMList = new List<StudentDetailViewModel>();

            try
            {
                var students = await _studentRepo.GetAllStudents(page, limit);

                foreach (var student in students)
                    studentVMList.Add(new StudentDetailViewModel { Student = student });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            if (studentVMList.Count == limit)
                ViewBag.NextPage = page + 1;

            if (page > 1)
                ViewBag.PrevPage = page - 1;

            return View(studentVMList);
        }

        // GET: Student/Details
        /// <summary>
        /// Fetches the details like studentProgram, studentQualifications, studentskills and loads the details page
        /// </summary>
        /// <param name="studentId">StudentId of student</param>
        public async Task<ActionResult> Details(int? studentId = null)
        {
            if (TempData["SuccessMessage"] != null)
                ViewBag.SuccessMessage = TempData["SuccessMessage"];

            if (studentId == null)
                return View();

            try
            {
                var student = await _studentRepo.GetStudent((int)studentId);

                var programsTask = Task.Run(() => _studentProgramRepo.GetAll((int)studentId));
                var qualificationsTask = Task.Run(() => _studentQualRepo.GetAll((int)studentId));
                var skillsTask = Task.Run(() => _studentSkillRepo.GetAll((int)studentId));

                Task.WaitAll();

                var studentDetail = new StudentDetailViewModel
                {
                    Student = student,
                    StudentPrograms = programsTask.Result,
                    StudentQualifications = qualificationsTask.Result,
                    StudentSkills = skillsTask.Result
                };

                return View(studentDetail);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
        /// <summary>
        /// This will register a new student and loads back the details page
        /// </summary>
        /// <param name="model">Student StudentRegisterViewModel object</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(StudentRegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid student details");

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
                string password = PasswordGenerator.GenerateRandom();
                var result = await UserManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // Assign student role
                    await UserManager.AddToRoleAsync(user.Id, "Student");

                    // Create Student
                    int studentId = await _studentRepo.CreateStudent(student);

                    TempData["SuccessMessage"] = "Student successfully registered! " +
                                          $"( Credentials - Username: {studentId}, Password: {password} )";

                    return RedirectToAction("Details", new { studentId });
                }
                AddErrors(result);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            ViewBag.States = new SelectList(SelectListItemHelper.GetIndianStates(), "Value", "Text");

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: Student/Update/5
        /// <summary>
        /// This will loads the details of existing student and loads the update form
        /// </summary>
        /// <param name="studentId">StudentId of student to be updated</param>
        public async Task<ActionResult> Update(int? studentId = null)
        {
            ViewBag.States = new SelectList(SelectListItemHelper.GetIndianStates(), "Value", "Text");

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
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: Student/Update/5
        /// <summary>
        /// This will update the details of existing student and redirects to the details page
        /// </summary>
        /// <param name="studentId">StudentId of student to be updated</param>
        /// <param name="model">Updated StudentRegisterViewModel model</param>
        [HttpPost]
        public async Task<ActionResult> Update(int studentId, StudentRegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid student details");
                
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

                TempData["SuccessMessage"] = "Student details updated!";
                return RedirectToAction("Details", new { studentId = studentId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int studentId)
        {
            return View();
        }

        // POST: Student/Delete/5
        /// <summary>
        /// This will delete the existing student and redirects back to the list page
        /// </summary>
        /// <param name="studentId">StudentId of student to be deleted</param>
        /// <param name="model">Optional StudentRegisterViewModel model</param>
        [HttpPost]
        public async Task<ActionResult> Delete(int studentId, StudentRegisterViewModel model)
        {
            try
            {
                await _studentRepo.DeleteStudent(studentId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
