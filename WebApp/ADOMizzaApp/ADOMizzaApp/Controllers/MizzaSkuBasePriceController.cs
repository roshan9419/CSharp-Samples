using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaSkuBasePriceController : Controller
    {
        BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaSkuBasePriceController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }
        // GET: MizzaSkuBasePrice
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaSkuBasePrice>("GetMizzaSkuBasePrices");

            return View(_bunchMizza.MizzaSkuBasePrices.ConvertToObjects(resultDT));
        }

        // GET: MizzaSkuBasePrice/Details/5
        public ActionResult Details(string id)
        {
            ModelState.Clear();

            MizzaSkuBasePrice mizzaFilter = new MizzaSkuBasePrice { SKUID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSkuBasePrices", mizzaFilter);
            var skuBasePrice = _bunchMizza.MizzaSkuBasePrices.ConvertToObjects(resultDT)[0];

            return View(skuBasePrice);
        }

        // GET: MizzaSkuBasePrice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSkuBasePrice/Create
        [HttpPost]
        public ActionResult Create(MizzaSkuBasePrice skuBasePrice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaSkuBasePrice", skuBasePrice))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaSkuBasePrice";
                return View();
            }
        }

        // GET: MizzaSkuBasePrice/Edit/5
        public ActionResult Edit(string id)
        {
            ModelState.Clear();

            MizzaSkuBasePrice mizzaFilter = new MizzaSkuBasePrice { SKUID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSkuBasePrices", mizzaFilter);
            var skuBasePrice = _bunchMizza.MizzaSkuBasePrices.ConvertToObjects(resultDT)[0];

            return View(skuBasePrice);
        }

        // POST: MizzaSkuBasePrice/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaSkuBasePrice skuBasePrice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    skuBasePrice.SKUID = id;
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaSkuBasePrice", skuBasePrice))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMessage = "Failed to update MizzaSkuBasePrice";
                return View();
            }
        }

        // GET: MizzaSkuBasePrice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaSkuBasePrice/Delete/5
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
