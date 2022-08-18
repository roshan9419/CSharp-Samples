using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtomCRUD.Models;

namespace AtomCRUD.Controllers
{
    public class MizzaToppingStylesController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaToppingStylesController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaToppingStyles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MizzaToppingStyles.ToListAsync());
        }

        // GET: MizzaToppingStyles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingStyle = await _context.MizzaToppingStyles
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingStyle == null)
            {
                return NotFound();
            }

            return View(mizzaToppingStyle);
        }

        // GET: MizzaToppingStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MizzaToppingStyles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToppingStyleId,ToppingName")] MizzaToppingStyle mizzaToppingStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaToppingStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mizzaToppingStyle);
        }

        // GET: MizzaToppingStyles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingStyle = await _context.MizzaToppingStyles.FindAsync(id);
            if (mizzaToppingStyle == null)
            {
                return NotFound();
            }
            return View(mizzaToppingStyle);
        }

        // POST: MizzaToppingStyles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ToppingStyleId,ToppingName")] MizzaToppingStyle mizzaToppingStyle)
        {
            if (id != mizzaToppingStyle.ToppingStyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaToppingStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaToppingStyleExists(mizzaToppingStyle.ToppingStyleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mizzaToppingStyle);
        }

        // GET: MizzaToppingStyles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingStyle = await _context.MizzaToppingStyles
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingStyle == null)
            {
                return NotFound();
            }

            return View(mizzaToppingStyle);
        }

        // POST: MizzaToppingStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaToppingStyle = await _context.MizzaToppingStyles.FindAsync(id);
            _context.MizzaToppingStyles.Remove(mizzaToppingStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaToppingStyleExists(string id)
        {
            return _context.MizzaToppingStyles.Any(e => e.ToppingStyleId == id);
        }
    }
}
