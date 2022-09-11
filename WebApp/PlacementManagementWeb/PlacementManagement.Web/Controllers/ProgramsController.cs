using PlacementManagement.Models;
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
    public class ProgramsController : Controller
    {
        private readonly IManageRepository<Program> _programRepo;
        public ProgramsController(IManageRepository<Program> programRepo)
        {
            _programRepo = programRepo;
        }

        // GET: Programs
        public async Task<ActionResult> Index()
        {
            var programs = new List<Program>();

            try
            {
                programs = await _programRepo.GetAll();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            if (TempData["ErrorMessage"] != null)
                ViewBag.ErrorMessage = TempData["ErrorMessage"];

            return View(programs);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        [HttpPost]
        public async Task<ActionResult> Create(Program program)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");

                await _programRepo.Create(program);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(program);
            }
        }

        // GET: Programs/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var program = await _programRepo.Get(id);
                return View(program);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Programs/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Program program)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");

                await _programRepo.Update(id, program);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(program);
            }
        }

        // GET: Programs/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var program = await _programRepo.Get(id);
                return View(program);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Programs/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Program program)
        {
            try
            {
                await _programRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(program);
            }
        }
    }
}
