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
    public class MizzaToppingsStyleSkusController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaToppingsStyleSkusController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaToppingsStyleSkus
        public async Task<IActionResult> Index()
        {
            var mIzzaNextContext = _context.MizzaToppingsStyleSkus.Include(m => m.ToppingStyle);
            return View(await mIzzaNextContext.ToListAsync());
        }

        // GET: MizzaToppingsStyleSkus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingsStyleSku = await _context.MizzaToppingsStyleSkus
                .Include(m => m.ToppingStyle)
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingsStyleSku == null)
            {
                return NotFound();
            }

            return View(mizzaToppingsStyleSku);
        }

        // GET: MizzaToppingsStyleSkus/Create
        public IActionResult Create()
        {
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingStyles, "ToppingStyleId", "ToppingStyleId");
            return View();
        }

        // POST: MizzaToppingsStyleSkus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToppingStyleId,ToppingSkuid")] MizzaToppingsStyleSku mizzaToppingsStyleSku)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaToppingsStyleSku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingStyles, "ToppingStyleId", "ToppingStyleId", mizzaToppingsStyleSku.ToppingStyleId);
            return View(mizzaToppingsStyleSku);
        }

        // GET: MizzaToppingsStyleSkus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingsStyleSku = await _context.MizzaToppingsStyleSkus.FindAsync(id);
            if (mizzaToppingsStyleSku == null)
            {
                return NotFound();
            }
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingStyles, "ToppingStyleId", "ToppingStyleId", mizzaToppingsStyleSku.ToppingStyleId);
            return View(mizzaToppingsStyleSku);
        }

        // POST: MizzaToppingsStyleSkus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ToppingStyleId,ToppingSkuid")] MizzaToppingsStyleSku mizzaToppingsStyleSku)
        {
            if (id != mizzaToppingsStyleSku.ToppingStyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaToppingsStyleSku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaToppingsStyleSkuExists(mizzaToppingsStyleSku.ToppingStyleId))
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
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingStyles, "ToppingStyleId", "ToppingStyleId", mizzaToppingsStyleSku.ToppingStyleId);
            return View(mizzaToppingsStyleSku);
        }

        // GET: MizzaToppingsStyleSkus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingsStyleSku = await _context.MizzaToppingsStyleSkus
                .Include(m => m.ToppingStyle)
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingsStyleSku == null)
            {
                return NotFound();
            }

            return View(mizzaToppingsStyleSku);
        }

        // POST: MizzaToppingsStyleSkus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaToppingsStyleSku = await _context.MizzaToppingsStyleSkus.FindAsync(id);
            _context.MizzaToppingsStyleSkus.Remove(mizzaToppingsStyleSku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaToppingsStyleSkuExists(string id)
        {
            return _context.MizzaToppingsStyleSkus.Any(e => e.ToppingStyleId == id);
        }
    }
}
