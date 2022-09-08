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
    public class StudentSkillsController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IStudentAcademicRepository<StudentSkill, Skill> _skillsRepo;
        public StudentSkillsController(IStudentRepository studentRepo, IStudentAcademicRepository<StudentSkill, Skill> skillsRepo)
        {
            _studentRepo = studentRepo;
            _skillsRepo = skillsRepo;
        }

        private async Task<Student> GetStudent()
        {
            var userId = User.Identity.GetUserId();
            return await _studentRepo.GetStudentByUserId(userId);
        }

        // GET: StudentSkill
        public async Task<ActionResult> Index()
        {
            var student = await GetStudent();
            var studentSkills = await _skillsRepo.GetAll(student.StudentId);
            
            var skills = new List<StudentSkillViewModel>();

            foreach (var skill in studentSkills)
            {
                skills.Add(new StudentSkillViewModel
                {
                    SkillId = skill.SkillId,
                    SkillName = skill.SkillName,
                    Experience = skill.Experience,
                    ProjectsDone = skill.ProjectsDone
                });
            }

            return View(skills);
        }

        // GET: StudentSkill/Create
        public async Task<ActionResult> Create()
        {
            var skills = await _skillsRepo.GetAll();
            ViewBag.Skills = new SelectList(skills, "SkillId", "SkillName");
            
            return View();
        }

        // POST: StudentSkill/Create
        [HttpPost]
        public async Task<ActionResult> Create(StudentSkillViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = await GetStudent();
                    var studentSkill = new StudentSkill
                    {
                        StudentId = student.StudentId,
                        SkillId = model.SkillId,
                        Experience = model.Experience,
                        ProjectsDone = model.ProjectsDone
                    };

                    await _skillsRepo.Add(studentSkill);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to add skill";
                return View();
            }
        }

        // GET: StudentSkill/Edit/5
        public async Task<ActionResult> Edit(int skillId)
        {
            try
            {
                var student = await GetStudent();
                var stdSkills = await _skillsRepo.GetAll(student.StudentId);

                StudentSkill selectedSkill = stdSkills.Find((skill) => skill.SkillId == skillId);

                if (selectedSkill == null)
                {
                    return HttpNotFound("Skill not exists");
                }

                var model = new StudentSkillViewModel
                {
                    SkillId = selectedSkill.SkillId,
                    SkillName = selectedSkill.SkillName,
                    Experience = selectedSkill.Experience,
                    ProjectsDone = selectedSkill.ProjectsDone
                };

                return View(model);
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to update skill";
                return View();
            }
        }

        // POST: StudentSkill/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(StudentSkillViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = await GetStudent();
                    var studentSkill = new StudentSkill
                    {
                        StudentId = student.StudentId,
                        SkillId = model.SkillId,
                        Experience = model.Experience,
                        ProjectsDone = model.ProjectsDone
                    };

                    await _skillsRepo.Update(studentSkill);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to update skill";
                return View();
            }
        }

        // GET: StudentSkill/Delete/5
        public async Task<ActionResult> Delete(int skillId)
        {
            try
            {
                var student = await GetStudent();
                var stdSkills = await _skillsRepo.GetAll(student.StudentId);

                StudentSkill selectedSkill = stdSkills.Find((skill) => skill.SkillId == skillId);

                if (selectedSkill == null)
                {
                    return HttpNotFound("Skill not exists");
                }

                var model = new StudentSkillViewModel
                {
                    SkillId = selectedSkill.SkillId,
                    SkillName = selectedSkill.SkillName,
                    Experience = selectedSkill.Experience,
                    ProjectsDone = selectedSkill.ProjectsDone
                };

                return View(model);
            }
            catch
            {
                ViewBag.ErrorMessage = "Failed to delete skill";
                return View();
            }
        }

        // POST: StudentSkill/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int skillId, StudentSkillViewModel model)
        {
            try
            {
                var student = await GetStudent();
                await _skillsRepo.Remove(student.StudentId, model.SkillId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
