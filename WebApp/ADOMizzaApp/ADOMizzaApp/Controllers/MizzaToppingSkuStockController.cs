using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaToppingSkuStockController : Controller
    {
        BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaToppingSkuStockController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }

        // GET: MizzaToppingSkuStock
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaToppingSKUStock>("GetMizzaToppingSkuStocks");

            return View(_bunchMizza.MizzaToppingSKUStocks.ConvertToObjects(resultDT));
        }

        // GET: MizzaToppingSkuStock/Details/5
        public ActionResult Details(string toppingStyleID, string skuid)
        {
            ModelState.Clear();

            MizzaToppingSKUPrice mizzaFilter = new MizzaToppingSKUPrice { ToppingStyleID = toppingStyleID, SKUID = skuid };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaToppingSkuStocks", mizzaFilter);
            var mizzaToppingSkuStock = _bunchMizza.MizzaToppingSKUPrices.ConvertToObjects(resultDT)[0];

            return View(mizzaToppingSkuStock);
        }

        // GET: MizzaToppingSkuStock/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaToppingSkuStock/Create
        [HttpPost]
        public ActionResult Create(MizzaToppingSKUStock mizzaToppingSkuStock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaToppingSkuStock", mizzaToppingSkuStock))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaToppingSKUStock";
                return View();
            }
        }

        // GET: MizzaToppingSkuStock/Edit/5
        public ActionResult Edit(string toppingStyleID, string skuid)
        {
            ModelState.Clear();

            MizzaToppingSKUPrice mizzaFilter = new MizzaToppingSKUPrice { ToppingStyleID = toppingStyleID, SKUID = skuid };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaToppingSkuPrices", mizzaFilter);
            var mizzaToppingSkuPrice = _bunchMizza.MizzaToppingSKUPrices.ConvertToObjects(resultDT)[0];

            return View(mizzaToppingSkuPrice);
        }

        // POST: MizzaToppingSkuStock/Edit/5
        [HttpPost]
        public ActionResult Edit(string toppingStyleID, string skuid, MizzaToppingSKUStock mizzaToppingSkuStock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaToppingSkuStock", mizzaToppingSkuStock))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to update MizzaToppingSKUStock";
                return View();
            }
        }

        // GET: MizzaToppingSkuStock/Delete/5
        public ActionResult Delete(string toppingStyleID, string skuid)
        {
            return View();
        }

        // POST: MizzaToppingSkuStock/Delete/5
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
