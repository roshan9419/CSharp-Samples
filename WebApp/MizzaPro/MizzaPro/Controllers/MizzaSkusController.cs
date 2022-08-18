using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MizzaPro.Models;

namespace MizzaPro.Controllers
{
    public class MizzaSkusController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaSkusController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaSkus
        public async Task<IActionResult> Index()
        {
            var mIzzaNextContext = _context.MizzaSkus.Include(m => m.MizzaSize).Include(m => m.MizzaStyle);
            return View(await mIzzaNextContext.ToListAsync());
        }

        // GET: MizzaSkus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSku = await _context.MizzaSkus
                .Include(m => m.MizzaSize)
                .Include(m => m.MizzaStyle)
                .FirstOrDefaultAsync(m => m.MizzaSkuid == id);
            if (mizzaSku == null)
            {
                return NotFound();
            }

            return View(mizzaSku);
        }

        // GET: MizzaSkus/Create
        public IActionResult Create()
        {
            ViewData["MizzaSizeId"] = new SelectList(_context.MizzaSizes, "MizzaSizeId", "MizzaSizeId");
            ViewData["MizzaStyleId"] = new SelectList(_context.MizzaStyles, "MizzaStyleId", "MizzaStyleId");
            return View();
        }

        // POST: MizzaSkus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MizzaSkuid,MizzaSkuname,MizzaStyleId,MizzaSizeId")] MizzaSku mizzaSku)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaSku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MizzaSizeId"] = new SelectList(_context.MizzaSizes, "MizzaSizeId", "MizzaSizeId", mizzaSku.MizzaSizeId);
            ViewData["MizzaStyleId"] = new SelectList(_context.MizzaStyles, "MizzaStyleId", "MizzaStyleId", mizzaSku.MizzaStyleId);
            return View(mizzaSku);
        }

        // GET: MizzaSkus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSku = await _context.MizzaSkus.FindAsync(id);
            if (mizzaSku == null)
            {
                return NotFound();
            }
            ViewData["MizzaSizeId"] = new SelectList(_context.MizzaSizes, "MizzaSizeId", "MizzaSizeId", mizzaSku.MizzaSizeId);
            ViewData["MizzaStyleId"] = new SelectList(_context.MizzaStyles, "MizzaStyleId", "MizzaStyleId", mizzaSku.MizzaStyleId);
            return View(mizzaSku);
        }

        // POST: MizzaSkus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MizzaSkuid,MizzaSkuname,MizzaStyleId,MizzaSizeId")] MizzaSku mizzaSku)
        {
            if (id != mizzaSku.MizzaSkuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaSku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaSkuExists(mizzaSku.MizzaSkuid))
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
            ViewData["MizzaSizeId"] = new SelectList(_context.MizzaSizes, "MizzaSizeId", "MizzaSizeId", mizzaSku.MizzaSizeId);
            ViewData["MizzaStyleId"] = new SelectList(_context.MizzaStyles, "MizzaStyleId", "MizzaStyleId", mizzaSku.MizzaStyleId);
            return View(mizzaSku);
        }

        // GET: MizzaSkus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSku = await _context.MizzaSkus
                .Include(m => m.MizzaSize)
                .Include(m => m.MizzaStyle)
                .FirstOrDefaultAsync(m => m.MizzaSkuid == id);
            if (mizzaSku == null)
            {
                return NotFound();
            }

            return View(mizzaSku);
        }

        // POST: MizzaSkus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaSku = await _context.MizzaSkus.FindAsync(id);
            _context.MizzaSkus.Remove(mizzaSku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaSkuExists(string id)
        {
            return _context.MizzaSkus.Any(e => e.MizzaSkuid == id);
        }
    }
}
