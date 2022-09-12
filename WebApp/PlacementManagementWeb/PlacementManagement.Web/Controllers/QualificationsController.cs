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
    public class QualificationsController : Controller
    {
        private readonly IManageRepository<QualificationType> _qualRepo;
        public QualificationsController(IManageRepository<QualificationType> qualRepo)
        {
            _qualRepo = qualRepo;
        }

        // GET: Qualifications
        public async Task<ActionResult> Index()
        {
            var qualTypes = new List<QualificationType>();

            try
            {
                qualTypes = await _qualRepo.GetAll();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            if (TempData["ErrorMessage"] != null)
                ViewBag.ErrorMessage = TempData["ErrorMessage"];

            return View(qualTypes);
        }

        // GET: Qualifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Qualifications/Create
        [HttpPost]
        public async Task<ActionResult> Create(QualificationType qualType)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");

                await _qualRepo.Create(qualType);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(qualType);
            }
        }

        // GET: Qualifications/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var qualType = await _qualRepo.Get(id);
                return View(qualType);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Qualifications/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, QualificationType qualType)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid details");
                
                await _qualRepo.Update(id, qualType);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(qualType);
            }
        }

        // GET: Qualifications/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var qualType = await _qualRepo.Get(id);
                return View(qualType);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Qualifications/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, QualificationType qualType)
        {
            try
            {
                await _qualRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(qualType);
            }
        }
    }
}
