using PlacementManagement.Models;
using PlacementManagement.Web.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillsController : Controller
    {
        private readonly IManageRepository<Skill> _skillRepo;
        public SkillsController(IManageRepository<Skill> skillRepo)
        {
            _skillRepo = skillRepo;
        }

        // GET: Skills
        public async Task<ActionResult> Index()
        {
            var skills = new List<Skill>();

            try
            {
                skills = await _skillRepo.GetAll();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            if (TempData["ErrorMessage"] != null)
                ViewBag.ErrorMessage = TempData["ErrorMessage"];

            return View(skills);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        public async Task<ActionResult> Create(Skill skill)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");

                await _skillRepo.Create(skill);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(skill);
            }
        }

        // GET: Skills/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var skill = await _skillRepo.Get(id);
                return View(skill);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Skills/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Skill skill)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");

                await _skillRepo.Update(id, skill);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(skill);
            }
        }

        // GET: Skills/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var skill = await _skillRepo.Get(id);
                return View(skill);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Skill skill)
        {
            try
            {
                await _skillRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(skill);
            }
        }
    }
}
