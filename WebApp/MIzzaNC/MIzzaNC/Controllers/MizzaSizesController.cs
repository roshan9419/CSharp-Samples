using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MIzzaNC.Models;

namespace MIzzaNC.Controllers
{
    public class MizzaSizesController : Controller
    {
        private MIzzaNextEntities db = new MIzzaNextEntities();

        // GET: MizzaSizes
        public async Task<ActionResult> Index()
        {
            return View(await db.MizzaSizes.ToListAsync());
        }

        // GET: MizzaSizes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaSize mizzaSize = db.MizzaSizes.Find(id);
            if (mizzaSize == null)
            {
                return HttpNotFound();
            }
            return View(mizzaSize);
        }

        // GET: MizzaSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MizzaSizeName,MizzaSizeID")] MizzaSize mizzaSize)
        {
            if (ModelState.IsValid)
            {
                db.MizzaSizes.Add(mizzaSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mizzaSize);
        }

        // GET: MizzaSizes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaSize mizzaSize = db.MizzaSizes.Find(id);
            if (mizzaSize == null)
            {
                return HttpNotFound();
            }
            return View(mizzaSize);
        }

        // POST: MizzaSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MizzaSizeName,MizzaSizeID")] MizzaSize mizzaSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mizzaSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mizzaSize);
        }

        // GET: MizzaSizes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaSize mizzaSize = db.MizzaSizes.Find(id);
            if (mizzaSize == null)
            {
                return HttpNotFound();
            }
            return View(mizzaSize);
        }

        // POST: MizzaSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MizzaSize mizzaSize = db.MizzaSizes.Find(id);
            db.MizzaSizes.Remove(mizzaSize);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
