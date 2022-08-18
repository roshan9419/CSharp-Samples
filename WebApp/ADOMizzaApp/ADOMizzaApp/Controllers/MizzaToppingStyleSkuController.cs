using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaToppingStyleSkuController : Controller
    {
        BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaToppingStyleSkuController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }

        // GET: MizzaToppingStyleSku
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaToppingsStyleSKU>("GetMizzaToppingStyleSkus");

            return View(_bunchMizza.MizzaToppingsStyleSKUs.ConvertToObjects(resultDT));
        }

        // GET: MizzaToppingStyleSku/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaToppingStyleSku/Create
        [HttpPost]
        public ActionResult Create(MizzaToppingsStyleSKU mizzaToppStyleSKU)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaToppingStyleSku", mizzaToppStyleSKU))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaToppingsStyleSKU";
                return View();
            }
        }

        // GET: MizzaToppingStyleSku/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaToppingStyleSku/Delete/5
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
