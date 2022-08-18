using Mizza.DataModels;
using MizzaWebApp.Repository;
using System.Web.Mvc;

namespace MizzaWebApp.Controllers
{
    public class MizzaSkuController : Controller
    {
        MizzaRepository _mizzaRepo;
        public MizzaSkuController()
        {
            _mizzaRepo = new MizzaRepository();
        }

        // GET: MizzaSku
        public ActionResult Index()
        {
            var mizzaSizes = _mizzaRepo.GetMany<MizzaSKU>("mizzaskus");
            return View(mizzaSizes);
        }

        // GET: MizzaSku/Details/5
        public ActionResult Details(string id)
        {
            var mizzaSize = _mizzaRepo.Get<MizzaSKU>($"mizzaskus/{id}");
            return View(mizzaSize);
        }

        // GET: MizzaSku/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSku/Create
        [HttpPost]
        public ActionResult Create(MizzaSKU mizzaSku)
        {
            try
            {
                _mizzaRepo.Create("mizzaskus", mizzaSku);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSku/Edit/5
        public ActionResult Edit(string id)
        {
            var mizzaSize = _mizzaRepo.Get<MizzaSKU>($"mizzaskus/{id}");
            return View(mizzaSize);
        }

        // POST: MizzaSku/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaSKU mizzaSku)
        {
            try
            {
                _mizzaRepo.Update($"mizzaskus/{id}", mizzaSku);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSku/Delete/5
        public ActionResult Delete(string id)
        {
            var mizzaSize = _mizzaRepo.Get<MizzaSKU>($"mizzaskus/{id}");
            return View(mizzaSize);
        }

        // POST: MizzaSku/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, MizzaSKU mizzaSku)
        {
            try
            {
                _mizzaRepo.Delete($"mizzaskus/{id}");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
