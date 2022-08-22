using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAuthIndividual.Models;

namespace MVCAuthIndividual.Controllers
{
    public class MizzaStylesController : Controller
    {
        private MizzaContext db = new MizzaContext();

        // GET: MizzaStyles
        public ActionResult Index()
        {
            return View(db.MizzaStyles.ToList());
        }

        // GET: MizzaStyles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaStyle mizzaStyle = db.MizzaStyles.Find(id);
            if (mizzaStyle == null)
            {
                return HttpNotFound();
            }
            return View(mizzaStyle);
        }

        // GET: MizzaStyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaStyles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MizzaStyleID,MizzaStyleName")] MizzaStyle mizzaStyle)
        {
            if (ModelState.IsValid)
            {
                db.MizzaStyles.Add(mizzaStyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mizzaStyle);
        }

        // GET: MizzaStyles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaStyle mizzaStyle = db.MizzaStyles.Find(id);
            if (mizzaStyle == null)
            {
                return HttpNotFound();
            }
            return View(mizzaStyle);
        }

        // POST: MizzaStyles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MizzaStyleID,MizzaStyleName")] MizzaStyle mizzaStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mizzaStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mizzaStyle);
        }

        // GET: MizzaStyles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaStyle mizzaStyle = db.MizzaStyles.Find(id);
            if (mizzaStyle == null)
            {
                return HttpNotFound();
            }
            return View(mizzaStyle);
        }

        // POST: MizzaStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MizzaStyle mizzaStyle = db.MizzaStyles.Find(id);
            db.MizzaStyles.Remove(mizzaStyle);
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
