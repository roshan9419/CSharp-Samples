using Mizza.DataModels;
using MizzaWebApp.Repository;
using System.Web.Mvc;

namespace MizzaWebApp.Controllers
{
    public class MizzaStyleController : Controller
    {
        MizzaRepository _mizzaRepo;
        public MizzaStyleController()
        {
            _mizzaRepo = new MizzaRepository();
        }

        // GET: MizzaStyle
        public ActionResult Index()
        {
            var mizzaSizes = _mizzaRepo.GetMany<MizzaStyle>("mizzastyles");
            return View(mizzaSizes);
        }

        // GET: MizzaStyle/Details/5
        public ActionResult Details(string id)
        {
            var mizzaSize = _mizzaRepo.Get<MizzaStyle>($"mizzastyles/{id}");
            return View(mizzaSize);
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
                _mizzaRepo.Create("mizzastyles", mizzaStyle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaStyle/Edit/5
        public ActionResult Edit(string id)
        {
            var mizzaSize = _mizzaRepo.Get<MizzaStyle>($"mizzastyles/{id}");
            return View(mizzaSize);
        }

        // POST: MizzaStyle/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaStyle mizzaStyle)
        {
            try
            {
                _mizzaRepo.Update($"mizzastyles/{id}", mizzaStyle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaStyle/Delete/5
        public ActionResult Delete(string id)
        {
            var mizzaSize = _mizzaRepo.Get<MizzaStyle>($"mizzastyles/{id}");
            return View(mizzaSize);
        }

        // POST: MizzaStyle/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, MizzaStyle mizzaStyle)
        {
            try
            {
                _mizzaRepo.Delete($"mizzastyles/{id}");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
