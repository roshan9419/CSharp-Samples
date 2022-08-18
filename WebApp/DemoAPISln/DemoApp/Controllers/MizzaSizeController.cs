using DemoApp.Clients;
using Mizza.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class MizzaSizeController : Controller
    {
        MizzaClient _mizzaClient;
        public MizzaSizeController()
        {
            _mizzaClient = new MizzaClient();
        }

        // GET: MizzaSize
        public ActionResult Index()
        {
            var mizzaSizes = _mizzaClient.GetMizzaSizes();
            return View(mizzaSizes);
        }

        // GET: MizzaSize/Details/5
        public ActionResult Details(string id)
        {
            var mizzaSize = _mizzaClient.GetMizzaSize(id);
            return View(mizzaSize);
        }

        // GET: MizzaSize/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSize/Create
        [HttpPost]
        public ActionResult Create(MizzaSize mizzaSize)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _mizzaClient.CreateMizzaSize(mizzaSize);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSize/Edit/5
        public ActionResult Edit(string id)
        {
            var mizzaSize = _mizzaClient.GetMizzaSize(id);
            return View(mizzaSize);
        }

        // POST: MizzaSize/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaSize mizzaSize)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _mizzaClient.UpdateMizzaSize(mizzaSize);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSize/Delete/5
        public ActionResult Delete(string id)
        {
            var mizzaSize = _mizzaClient.GetMizzaSize(id);
            return View(mizzaSize);
        }

        // POST: MizzaSize/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _mizzaClient.DeleteMizzaSize(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
