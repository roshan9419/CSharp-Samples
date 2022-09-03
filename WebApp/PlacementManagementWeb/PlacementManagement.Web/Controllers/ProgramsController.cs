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
            var list = await _programRepo.GetAll();
            return View(list);
        }

        // GET: Programs/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var program = await _programRepo.Get(id);
            return View(program);
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
                if (ModelState.IsValid)
                {
                    await _programRepo.Create(program);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Programs/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var program = await _programRepo.Get(id);
            return View(program);
        }

        // POST: Programs/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Program program)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _programRepo.Update(id, program);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Programs/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var program = await _programRepo.Get(id);
            return View(program);
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
            catch
            {
                return View();
            }
        }
    }
}
