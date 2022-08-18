using Mizza.DataModels;
using MizzaWebApp.Repository;
using System.Web.Mvc;

namespace MizzaWebApp.Controllers
{
    public class MizzaToppingStyleController : Controller
    {
        MizzaRepository _mizzaRepo;
        public MizzaToppingStyleController()
        {
            _mizzaRepo = new MizzaRepository();
        }

        // GET: MizzaToppingStyle
        public ActionResult Index()
        {
            var mizzaToppStyles = _mizzaRepo.GetMany<MizzaToppingStyle>("mizzatoppingstyles");
            return View(mizzaToppStyles);
        }

        // GET: MizzaToppingStyle/Details/5
        public ActionResult Details(string id)
        {
            var mizzaToppStyle = _mizzaRepo.Get<MizzaToppingStyle>($"mizzatoppingstyles/{id}");
            return View(mizzaToppStyle);
        }

        // GET: MizzaToppingStyle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaToppingStyle/Create
        [HttpPost]
        public ActionResult Create(MizzaToppingStyle mizzaToppStyle)
        {
            try
            {
                _mizzaRepo.Create("mizzatoppingstyles", mizzaToppStyle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaToppingStyle/Edit/5
        public ActionResult Edit(string id)
        {
            var mizzaToppStyle = _mizzaRepo.Get<MizzaToppingStyle>($"mizzatoppingstyles/{id}");
            return View(mizzaToppStyle);
        }

        // POST: MizzaToppingStyle/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, MizzaToppingStyle mizzaToppStyle)
        {
            try
            {
                _mizzaRepo.Update($"mizzatoppingstyles/{id}", mizzaToppStyle);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaToppingStyle/Delete/5
        public ActionResult Delete(string id)
        {
            var mizzaToppStyle = _mizzaRepo.Get<MizzaToppingStyle>($"mizzatoppingstyles/{id}");
            return View(mizzaToppStyle);
        }

        // POST: MizzaToppingStyle/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, MizzaToppingStyle mizzaToppStyle)
        {
            try
            {
                _mizzaRepo.Delete($"mizzatoppingstyles/{id}");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
