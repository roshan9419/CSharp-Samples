using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaSKUController : Controller
    {
        BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaSKUController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }

        // GET: MizzaSKU
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaSKU>("GetMizzaSkus");

            return View(_bunchMizza.MizzaSkus.ConvertToObjects(resultDT));
        }

        // GET: MizzaSKU/Details/5
        public ActionResult Details(string id)
        {
            ModelState.Clear();

            MizzaSKU mizzaFilter = new MizzaSKU { MizzaSKUID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSkus", mizzaFilter);
            var mizzaSku = _bunchMizza.MizzaSkus.ConvertToObjects(resultDT)[0];

            return View(mizzaSku);
        }

        // GET: MizzaSKU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSKU/Create
        [HttpPost]
        public ActionResult Create(MizzaSKU mizzaSKU)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaSku", mizzaSKU))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaSKU";
                return View();
            }
        }

        // GET: MizzaSKU/Edit/5
        public ActionResult Edit(string id)
        {
            ModelState.Clear();

            MizzaSKU mizzaFilter = new MizzaSKU { MizzaSKUID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSkus", mizzaFilter);
            var mizzaSku = _bunchMizza.MizzaSkus.ConvertToObjects(resultDT)[0];

            return View(mizzaSku);
        }

        // POST: MizzaSKU/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaSKU mizzaSKU)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mizzaSKU.MizzaSKUID = id;
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaSku", mizzaSKU))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMessage = "Failed to update MizzaSKU";
                return View();
            }
        }

        // GET: MizzaSKU/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaSKU/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
