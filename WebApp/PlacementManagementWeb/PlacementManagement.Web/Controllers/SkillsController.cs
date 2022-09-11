using PlacementManagement.Models;
using PlacementManagement.Web.Repository;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PlacementManagement.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillsController : Controller
    {
        private readonly IManageRepository<Skill> _skillRepo;
        public SkillsController(IManageRepository<Skill> skillRepo)
        {
            _skillRepo = skillRepo;
        }

        // GET: Skills
        public async Task<ActionResult> Index()
        {
            var list = await _skillRepo.GetAll();
            return View(list);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        public async Task<ActionResult> Create(Skill skill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _skillRepo.Create(skill);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skills/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var skill = await _skillRepo.Get(id);
            return View(skill);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Skill skill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _skillRepo.Update(id, skill);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skills/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var skill = await _skillRepo.Get(id);
            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Skill skill)
        {
            try
            {
                await _skillRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
