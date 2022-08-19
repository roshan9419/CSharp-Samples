using MVCAuthIndividual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthIndividual.Controllers
{
    public class MizzaSizeController : Controller
    {
        private readonly MizzaContext _context;

        public MizzaSizeController(MizzaContext context)
        {
            _context = context;
        }

        // GET: MizzaSize
        public async Task<ActionResult> Index()
        {
            return View(await _context.MizzaSizes.ToListAsync());
        }

        // GET: MizzaSize/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MizzaSize/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSize/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSize/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MizzaSize/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSize/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaSize/Delete/5
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
