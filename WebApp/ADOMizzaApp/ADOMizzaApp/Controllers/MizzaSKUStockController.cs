using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaSKUStockController : Controller
    {
        private BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaSKUStockController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }
        
        // GET: MizzaSKUStock
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaSKUStock>("GetMizzaSkuStocks");

            return View(_bunchMizza.MizzaSkuStocks.ConvertToObjects(resultDT));
        }

        // GET: MizzaSKUStock/Details/5
        public ActionResult Details(string id)
        {
            ModelState.Clear();

            MizzaSKUStock mizzaFilter = new MizzaSKUStock { SKUID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSkuStocks", mizzaFilter);
            var mizzaSkuStock = _bunchMizza.MizzaSkuStocks.ConvertToObjects(resultDT)[0];

            return View(mizzaSkuStock);
        }

        // GET: MizzaSKUStock/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSKUStock/Create
        [HttpPost]
        public ActionResult Create(MizzaSKUStock mizzaSKUStock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaSkuStock", mizzaSKUStock))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaSKUStock";
                return View();
            }
        }

        // GET: MizzaSKUStock/Edit/5
        public ActionResult Edit(string id)
        {
            ModelState.Clear();

            MizzaSKUStock mizzaFilter = new MizzaSKUStock { SKUID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSkuStocks", mizzaFilter);
            var mizzaSkuStock = _bunchMizza.MizzaSkuStocks.ConvertToObjects(resultDT)[0];

            return View(mizzaSkuStock);
        }

        // POST: MizzaSKUStock/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaSKUStock mizzaSKUStock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mizzaSKUStock.SKUID = id;
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaSkuStock", mizzaSKUStock))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMessage = "Failed to update MizzaSKUStock";
                return View();
            }
        }

        // GET: MizzaSKUStock/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaSKUStock/Delete/5
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
