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
        public async Task<ActionResult> Index()
        {
            //List<Student> model = await GetStudents();
            List<SelectListItem> genders = new List<SelectListItem>
            {
                new SelectListItem { Text = "Male", Value = "1" },
                new SelectListItem { Text = "Female", Value = "2" }
            };
            
            ViewBag.Genders = new SelectList(genders, "Value", "Text");
            ViewBag.Programs = new SelectList(await _programRepo.GetAll(), "ProgramId", "ProgramName");
            ViewBag.Skills = new SelectList(await _skillRepo.GetAll(), "SkillId", "SkillName");
            ViewBag.Qualifications = new SelectList(await _qualRepo.GetAll(), "Id", "Name");

            return View();
        }
        public async Task<PartialViewResult> SearchStudents(StudentFilter filter)
        {
            List<Student> model = await _studentRepo.GetFilteredStudents(filter);
            return PartialView("_GridView", model);
        }
    }
}
