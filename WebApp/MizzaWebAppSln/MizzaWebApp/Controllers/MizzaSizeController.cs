using Mizza.DataModels;
using MizzaWebApp.Repository;
using System.Web.Mvc;

namespace MizzaWebApp.Controllers
{
    public class MizzaSizeController : Controller
    {
        MizzaRepository _mizzaRepo;
        public MizzaSizeController()
        {
            _mizzaRepo = new MizzaRepository();
        }

        // GET: MizzaSize
        public ActionResult Index()
        {
            var mizzaSizes = _mizzaRepo.GetMany<MizzaSize>("mizzasizes");
            return View(mizzaSizes);
        }

        // GET: MizzaSize/Details/5
        public ActionResult Details(string id)
        {
            var mizzaSize = _mizzaRepo.Get<MizzaSize>($"mizzasizes/{id}");
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
                _mizzaRepo.Create("mizzasizes", mizzaSize);
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
            var mizzaSize = _mizzaRepo.Get<MizzaSize>($"mizzasizes/{id}");
            return View(mizzaSize);
        }

        // POST: MizzaSize/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaSize mizzaSize)
        {
            try
            {
                _mizzaRepo.Update($"mizzasizes/{id}", mizzaSize);
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
            var mizzaSize = _mizzaRepo.Get<MizzaSize>($"mizzasizes/{id}");
            return View(mizzaSize);
        }

        // POST: MizzaSize/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, MizzaSize mizzaSize)
        {
            try
            {
                _mizzaRepo.Delete($"mizzasizes/{id}");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
