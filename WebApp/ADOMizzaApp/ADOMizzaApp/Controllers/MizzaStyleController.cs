using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaStyleController : Controller
    {
        BunchMizza _bunchMizza;
        CommandViewModel _commandVM;
        public MizzaStyleController()
        {
            _bunchMizza = new BunchMizza();
            _commandVM = new CommandViewModel("MIzzaNextDB");
        }

        // GET: MizzaStyle
        public ActionResult Index()
        {
            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure<MizzaStyle>("GetMizzaStyles");

            return View(_bunchMizza.MizzaStyles.ConvertToObjects(resultDT));
        }

        // GET: MizzaStyle/Details/5
        public ActionResult Details(string id)
        {
            ModelState.Clear();

            MizzaStyle mizzaFilter = new MizzaStyle { MizzaStyleID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaStyles", mizzaFilter);
            var mizzaStyle = _bunchMizza.MizzaStyles.ConvertToObjects(resultDT)[0];

            return View(mizzaStyle);
        }

        // GET: MizzaStyle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaStyle/Create
        [HttpPost]
        public ActionResult Create(MizzaStyle mizzaStyle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaStyle", mizzaStyle))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMesssage = "Failed to create MizzaStyle";
                return View();
            }
        }

        // GET: MizzaStyle/Edit/5
        public ActionResult Edit(string id)
        {
            ModelState.Clear();

            MizzaStyle mizzaFilter = new MizzaStyle { MizzaStyleID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaStyles", mizzaFilter);
            var mizzaStyle = _bunchMizza.MizzaStyles.ConvertToObjects(resultDT)[0];

            return View(mizzaStyle);
        }

        // POST: MizzaStyle/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaStyle mizzaStyle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mizzaStyle.MizzaStyleID = id;
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaStyle", mizzaStyle))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMessage = "Failed to update MizzaStyle";
                return View();
            }
        }

        // GET: MizzaStyle/Delete/5
        public ActionResult Delete(string id)
        {
            ModelState.Clear();

            MizzaStyle mizzaFilter = new MizzaStyle { MizzaStyleID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaStyles", mizzaFilter);
            var mizzaStyle = _bunchMizza.MizzaStyles.ConvertToObjects(resultDT)[0];

            return View(mizzaStyle);
        }

        // POST: MizzaStyle/Delete/5
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
