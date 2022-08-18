using ADOMizzaApp.Repository;
using Mizza.DataModels;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mizza.Controllers
{
    public class MizzaSizeController : Controller
    {
        private BunchMizza _bunchMizza;
        //private CommandViewModel _commandVM;
        private MySQLCommandViewModel _commandVM;

        public MizzaSizeController()
        {
            _bunchMizza = new BunchMizza();
            //_commandVM = new CommandViewModel("MIzzaNextDB");
            _commandVM = new MySQLCommandViewModel("MIzzaNextDBMySql");
        }

        // GET: MizzaSizes
        public ActionResult Index()
        {
            #region old logic
            //var mizzaRepo = new MizzaRepository("MIzzaNextDB");
            //ModelState.Clear();
            //return View(mizzaRepo.GetAllMizzaSizes("GetMizzaSizes"));
            #endregion

            ModelState.Clear();

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSizes");
            var mizzaSizeList = _bunchMizza.MizzaSizes.ConvertToObjects(resultDT);
            
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }

            return View(mizzaSizeList);
        }

        // GET: MizzaSizes/Details/5
        public ActionResult Details(string id)
        {
            ModelState.Clear();

            MizzaSize mizzaFilter = new MizzaSize { MizzaSizeID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSizes", id);
            var mizzaSize = _bunchMizza.MizzaSizes.ConvertToObjects(resultDT)[0];

            return View(mizzaSize);
        }

        // GET: MizzaSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSizes/Create
        [HttpPost]
        public ActionResult Create(MizzaSize mizzaSize)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("CreateMizzaSize", mizzaSize))
                    {
                        throw new Exception("Failed to insert");
                    }
                }
                TempData["SuccessMessage"] = "New record inserted";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMessage = "Failed to insert MizzaSize";
                return View();
            }
        }

        // GET: MizzaSizes/Edit/5
        public ActionResult Edit(string id)
        {
            ModelState.Clear();

            MizzaSize mizzaFilter = new MizzaSize { MizzaSizeID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSizes", id);
            var mizzaSize = _bunchMizza.MizzaSizes.ConvertToObjects(resultDT)[0];

            return View(mizzaSize);
        }

        // POST: MizzaSizes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaSize mizzaSize)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mizzaSize.MizzaSizeID = id;
                    if (!_commandVM.CreateOrUpdateUsingStoredProcedure("UpdateMizzaSize", mizzaSize))
                    {
                        throw new Exception("Failed to update");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMessage = "Failed to update MizzaSize";
                return View();
            }
        }

        // GET: MizzaSizes/Delete/5
        public ActionResult Delete(string id)
        {
            ModelState.Clear();

            MizzaSize mizzaFilter = new MizzaSize { MizzaSizeID = id };

            var resultDT = _commandVM.GetRecordsUsingStoredProcedure("GetMizzaSizes", id);
            var mizzaSize = _bunchMizza.MizzaSizes.ConvertToObjects(resultDT)[0];

            return View(mizzaSize);
        }

        // POST: MizzaSizes/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, MizzaSize mizzaSize)
        {
            try
            {
                ModelState.Clear();
                mizzaSize.MizzaSizeID = id;
                if (!_commandVM.DeleteUsingStoredProcedure("DeleteMizzaSize", mizzaSize))
                {
                    throw new Exception("Failed to delete");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.FailedMessage = "Failed to delete MizzaSize";
                return View();
            }
        }
    }
}
