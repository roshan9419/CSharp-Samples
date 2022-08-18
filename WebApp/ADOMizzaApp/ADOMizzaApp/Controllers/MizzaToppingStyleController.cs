using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaToppingStyleController : Controller
    {
        BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaToppingStyleController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }

        // GET: MizzaToppingStyle
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaToppingStyle>("GetMizzaToppingStyles");

            return View(_bunchMizza.MizzaToppingStyles.ConvertToObjects(resultDT));
        }

        // GET: MizzaToppingStyle/Details/5
        public ActionResult Details(string id)
        {
            ModelState.Clear();

            MizzaToppingStyle mizzaFilter = new MizzaToppingStyle { ToppingStyleID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaToppingStyles", mizzaFilter);
            var mizzaToppStyle = _bunchMizza.MizzaStyles.ConvertToObjects(resultDT)[0];

            return View(mizzaToppStyle);
        }

        // GET: MizzaToppingStyle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaToppingStyle/Create
        [HttpPost]
        public ActionResult Create(MizzaToppingStyle mizzaToppStyle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaToppingStyle", mizzaToppStyle))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaToppingStyle";
                return View();
            }
        }

        // GET: MizzaToppingStyle/Edit/5
        public ActionResult Edit(string id)
        {
            ModelState.Clear();

            MizzaToppingStyle mizzaFilter = new MizzaToppingStyle { ToppingStyleID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaToppingStyles", mizzaFilter);
            var mizzaToppStyle = _bunchMizza.MizzaStyles.ConvertToObjects(resultDT)[0];

            return View(mizzaToppStyle);
        }

        // POST: MizzaToppingStyle/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaToppingStyle mizzaToppStyle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaToppingStyle", mizzaToppStyle))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to update MizzaToppingStyle";
                return View();
            }
        }

        // GET: MizzaToppingStyle/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: MizzaToppingStyle/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
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
