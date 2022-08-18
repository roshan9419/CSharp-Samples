using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaToppingSkuPriceController : Controller
    {
        BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaToppingSkuPriceController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }

        // GET: MizzaToppingSkuPrice
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaToppingSKUPrice>("GetMizzaToppingSkuPrices");

            return View(_bunchMizza.MizzaToppingSKUPrices.ConvertToObjects(resultDT));
        }

        // GET: MizzaToppingSkuPrice/Details/5
        public ActionResult Details(string toppingStyleID, string skuid)
        {
            ModelState.Clear();

            MizzaToppingSKUPrice mizzaFilter = new MizzaToppingSKUPrice { ToppingStyleID = toppingStyleID, SKUID = skuid };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaToppingSkuPrices", mizzaFilter);
            var mizzaToppingSkuPrice = _bunchMizza.MizzaToppingSKUPrices.ConvertToObjects(resultDT)[0];

            return View(mizzaToppingSkuPrice);
        }

        // GET: MizzaToppingSkuPrice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaToppingSkuPrice/Create
        [HttpPost]
        public ActionResult Create(MizzaToppingSKUPrice mizzaToppingSkuPrice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaToppingSkuPrice", mizzaToppingSkuPrice))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaToppingSKUPrice";
                return View();
            }
        }

        // GET: MizzaToppingSkuPrice/Edit/5
        public ActionResult Edit(string toppingStyleID, string skuid)
        {
            ModelState.Clear();

            MizzaToppingSKUPrice mizzaFilter = new MizzaToppingSKUPrice { ToppingStyleID = toppingStyleID, SKUID = skuid };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaToppingSkuPrices", mizzaFilter);
            var mizzaToppingSkuPrice = _bunchMizza.MizzaToppingSKUPrices.ConvertToObjects(resultDT)[0];

            return View(mizzaToppingSkuPrice);
        }

        // POST: MizzaToppingSkuPrice/Edit/5
        [HttpPost]
        public ActionResult Edit(string toppingStyleID, string skuid, MizzaToppingSKUPrice mizzaToppingSkuPrice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaToppingSkuPrice", mizzaToppingSkuPrice))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to update MizzaToppingSKUPrice";
                return View();
            }
        }

        // GET: MizzaToppingSkuPrice/Delete/5
        public ActionResult Delete(string toppingStyleID, string skuid)
        {
            return View();
        }

        // POST: MizzaToppingSkuPrice/Delete/5
        [HttpPost]
        public ActionResult Delete(string toppingStyleID, string skuid, FormCollection collection)
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
