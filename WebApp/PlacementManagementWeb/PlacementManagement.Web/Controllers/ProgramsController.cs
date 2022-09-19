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
        /// <summary>
        /// This will fetch all the programs and loads the page
        /// </summary>
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

            if (TempData["SuccessMessage"] != null)
                ViewBag.SuccessMessage = TempData["SuccessMessage"];

            return View(programs);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        /// <summary>
        /// This will create a new Program and redirects back to list page
        /// </summary>
        /// <param name="program">Details of the new program</param>
        [HttpPost]
        public async Task<ActionResult> Create(Program program)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");

                await _programRepo.Create(program);

                TempData["SuccessMessage"] = "New program added successfully!";
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
        /// <summary>
        /// This will update the details of existing program and redirects back to list page
        /// </summary>
        /// <param name="id">Id of the program</param>
        /// <param name="program">Update program object</param>
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Program program)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");

                await _programRepo.Update(id, program);

                TempData["SuccessMessage"] = "Program details updated!";
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
        /// <summary>
        /// This will delete the existing program and redirects back to list page
        /// </summary>
        /// <param name="id">Id of the program</param>
        /// <param name="program">Optional program</param>
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Program program)
        {
            try
            {
                await _programRepo.Delete(id);

                TempData["SuccessMessage"] = $"{program.ProgramName} deleted successfuly!";
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
