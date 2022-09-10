using Microsoft.AspNet.Identity;
using PlacementManagement.Models;
using PlacementManagement.Web.Repository;
using PlacementManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers
{
    [Authorize(Roles = "Student")]
    public class ProfileController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IStudentAcademicRepository<StudentProgram, Program> _studentProgramRepo;
        private readonly IStudentAcademicRepository<StudentQualification, QualificationType> _studentQualRepo;

        public ProfileController(
            IStudentRepository studentRepo,
            IStudentAcademicRepository<StudentProgram, Program> studentProgramRepo,
            IStudentAcademicRepository<StudentQualification, QualificationType> studentQualRepo)
        {
            _studentRepo = studentRepo;
            _studentProgramRepo = studentProgramRepo;
            _studentQualRepo = studentQualRepo;
        }

        // GET: Profile
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            
            try
            {
                var student = await _studentRepo.GetStudentByUserId(userId);
                var programsTask = Task.Run(() => _studentProgramRepo.GetAll(student.StudentId));
                var qualificationsTask = Task.Run(() => _studentQualRepo.GetAll(student.StudentId));

                Task.WaitAll();

                var studentDetail = new StudentDetailViewModel
                {
                    Student = student,
                    StudentPrograms = programsTask.Result,
                    StudentQualifications = qualificationsTask.Result
                };

                return View(studentDetail);
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
