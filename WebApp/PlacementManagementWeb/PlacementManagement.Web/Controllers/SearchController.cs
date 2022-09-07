using PlacementManagement.Models;
using PlacementManagement.Models.Enums;
using PlacementManagement.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SearchController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IManageRepository<Program> _programRepo;
        private readonly IManageRepository<Skill> _skillRepo;
        private readonly IManageRepository<QualificationType> _qualRepo;

        public SearchController(IStudentRepository studentRepo, IManageRepository<Program> programRepo, IManageRepository<Skill> skillRepo, IManageRepository<QualificationType> qualRepo)
        {
            _studentRepo = studentRepo;
            _programRepo = programRepo;
            _skillRepo = skillRepo;
            _qualRepo = qualRepo;
        }

        // GET: Search
        public ActionResult Index()
        {
            List<SelectListItem> genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Male", Value = "1" },
                new SelectListItem { Text = "Female", Value = "2" }
            };
            
            var programTask = Task.Run(() => _programRepo.GetAll());
            var skillTask = Task.Run(() => _skillRepo.GetAll());
            var qualTask = Task.Run(() => _qualRepo.GetAll());

            Task.WaitAll();

            ViewBag.Genders = new SelectList(genders, "Value", "Text");
            ViewBag.Programs = new SelectList(programTask.Result, "ProgramId", "ProgramName");
            ViewBag.Skills = new SelectList(skillTask.Result, "SkillId", "SkillName");
            ViewBag.Qualifications = new SelectList(qualTask.Result, "Id", "Name");

            return View();
        }
        public async Task<PartialViewResult> SearchStudents(StudentFilter filter)
        {
            List<Student> students = await _studentRepo.GetFilteredStudents(filter);

            if (students.Count == filter.Limit)
                ViewBag.NextPage = filter.Page + 1;

            if (filter.Page > 1)
                ViewBag.PrevPage = filter.Page - 1;

            return PartialView("_GridView", students);
        }
    }
}
