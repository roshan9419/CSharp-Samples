using Mizza.DataModels;
using MizzaWebApp.Models;
using MizzaWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MizzaWebApp.Controllers
{
    public class SizeStyleController : Controller
    {
        MizzaRepository _mizzaRepo;
        public SizeStyleController()
        {
            _mizzaRepo = new MizzaRepository();
        }

        // GET: SizeStyle
        public ActionResult Index()
        {
            var sizes = _mizzaRepo.GetMany<MizzaSize>("mizzasizes");
            var styles = _mizzaRepo.GetMany<MizzaStyle>("mizzastyles");

            var sizeStyles = new List<SizeStyleModel>();

            for (int i = 0; i < Math.Min(sizes.Count, styles.Count); i++)
            {
                sizeStyles.Add(new SizeStyleModel
                {
                    MizzaSize = sizes[i],
                    MizzaStyle = styles[i]
                });
            }

            return View(sizeStyles);
        }

        // GET: SizeStyle/Index/32
        public ActionResult FilterIndex(string id)
        {
            var styles = _mizzaRepo.GetMany<MizzaStyle>("mizzastyles");
            var sizes = new List<MizzaSize>();
            var sizeStyles = new List<SizeStyleModel>();

            if (id != null && id.Length != 0)
            {
                var size = _mizzaRepo.Get<MizzaSize>($"mizzasizes/{id}");
                sizes.Add(size);
            }
            else
            {
                sizes = _mizzaRepo.GetMany<MizzaSize>("mizzasizes");
            }


            for (int i = 0; i < sizes.Count; i++)
            {
                sizeStyles.Add(new SizeStyleModel
                {
                    MizzaSize = sizes[i]
                });
            }

            for (int i = 0; i < styles.Count; i++)
            {
                sizeStyles.Add(new SizeStyleModel
                {
                    MizzaStyle = styles[i]
                });
            }

            return View(sizeStyles);
        }

        // GET: SizeStyle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SizeStyle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeStyle/Create
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

        // GET: SizeStyle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SizeStyle/Edit/5
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

        // GET: SizeStyle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SizeStyle/Delete/5
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
