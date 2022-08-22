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
    public class MizzaSKUsController : Controller
    {
        private MizzaContext db = new MizzaContext();

        // GET: MizzaSKUs
        public ActionResult Index()
        {
            var mizzaSKUs = db.MizzaSKUs.Include(m => m.MizzaSize).Include(m => m.MizzaSkuBasePrice).Include(m => m.MizzaSKUStock).Include(m => m.MizzaStyle);
            return View(mizzaSKUs.ToList());
        }

        // GET: MizzaSKUs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaSKU mizzaSKU = db.MizzaSKUs.Find(id);
            if (mizzaSKU == null)
            {
                return HttpNotFound();
            }
            return View(mizzaSKU);
        }

        // GET: MizzaSKUs/Create
        public ActionResult Create()
        {
            ViewBag.MizzaSizeID = new SelectList(db.MizzaSizes, "MizzaSizeID", "MizzaSizeName");
            ViewBag.MizzaStyleID = new SelectList(db.MizzaStyles, "MizzaStyleID", "MizzaStyleName");
            return View();
        }

        // POST: MizzaSKUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MizzaSKUID,MizzaSKUName,MizzaStyleID,MizzaSizeID")] MizzaSKU mizzaSKU)
        {
            if (ModelState.IsValid)
            {
                db.MizzaSKUs.Add(mizzaSKU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MizzaSizeID = new SelectList(db.MizzaSizes, "MizzaSizeID", "MizzaSizeName");
            ViewBag.MizzaStyleID = new SelectList(db.MizzaStyles, "MizzaStyleID", "MizzaStyleName");
            return View(mizzaSKU);
        }

        // GET: MizzaSKUs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaSKU mizzaSKU = db.MizzaSKUs.Find(id);
            if (mizzaSKU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MizzaSizeID = new SelectList(db.MizzaSizes, "MizzaSizeID", "MizzaSizeName", mizzaSKU.MizzaSizeID);
            ViewBag.MizzaSKUID = new SelectList(db.MizzaSkuBasePrices, "SKUID", "SKUID", mizzaSKU.MizzaSKUID);
            ViewBag.MizzaSKUID = new SelectList(db.MizzaSKUStocks, "SKUID", "StockCount", mizzaSKU.MizzaSKUID);
            ViewBag.MizzaStyleID = new SelectList(db.MizzaStyles, "MizzaStyleID", "MizzaStyleName", mizzaSKU.MizzaStyleID);
            return View(mizzaSKU);
        }

        // POST: MizzaSKUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MizzaSKUID,MizzaSKUName,MizzaStyleID,MizzaSizeID")] MizzaSKU mizzaSKU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mizzaSKU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MizzaSizeID = new SelectList(db.MizzaSizes, "MizzaSizeID", "MizzaSizeName", mizzaSKU.MizzaSizeID);
            ViewBag.MizzaSKUID = new SelectList(db.MizzaSkuBasePrices, "SKUID", "SKUID", mizzaSKU.MizzaSKUID);
            ViewBag.MizzaSKUID = new SelectList(db.MizzaSKUStocks, "SKUID", "StockCount", mizzaSKU.MizzaSKUID);
            ViewBag.MizzaStyleID = new SelectList(db.MizzaStyles, "MizzaStyleID", "MizzaStyleName", mizzaSKU.MizzaStyleID);
            return View(mizzaSKU);
        }

        // GET: MizzaSKUs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MizzaSKU mizzaSKU = db.MizzaSKUs.Find(id);
            if (mizzaSKU == null)
            {
                return HttpNotFound();
            }
            return View(mizzaSKU);
        }

        // POST: MizzaSKUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MizzaSKU mizzaSKU = db.MizzaSKUs.Find(id);
            db.MizzaSKUs.Remove(mizzaSKU);
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
