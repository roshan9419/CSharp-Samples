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
    public class MizzaToppingSkustocksController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaToppingSkustocksController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaToppingSkustocks
        public async Task<IActionResult> Index()
        {
            var mIzzaNextContext = _context.MizzaToppingSkustocks.Include(m => m.MizzaToppingsStyleSku);
            return View(await mIzzaNextContext.ToListAsync());
        }

        // GET: MizzaToppingSkustocks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingSkustock = await _context.MizzaToppingSkustocks
                .Include(m => m.MizzaToppingsStyleSku)
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingSkustock == null)
            {
                return NotFound();
            }

            return View(mizzaToppingSkustock);
        }

        // GET: MizzaToppingSkustocks/Create
        public IActionResult Create()
        {
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId");
            ViewData["Skuid"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingSkuid", "ToppingSkuid");
            return View();
        }

        // POST: MizzaToppingSkustocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToppingStyleId,Skuid,StockCount")] MizzaToppingSkustock mizzaToppingSkustock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaToppingSkustock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId", mizzaToppingSkustock.ToppingStyleId);
            return View(mizzaToppingSkustock);
        }

        // GET: MizzaToppingSkustocks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingSkustock = await _context.MizzaToppingSkustocks.FindAsync(id);
            if (mizzaToppingSkustock == null)
            {
                return NotFound();
            }
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId", mizzaToppingSkustock.ToppingStyleId);
            return View(mizzaToppingSkustock);
        }

        // POST: MizzaToppingSkustocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ToppingStyleId,Skuid,StockCount")] MizzaToppingSkustock mizzaToppingSkustock)
        {
            if (id != mizzaToppingSkustock.ToppingStyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaToppingSkustock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaToppingSkustockExists(mizzaToppingSkustock.ToppingStyleId))
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
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId", mizzaToppingSkustock.ToppingStyleId);
            return View(mizzaToppingSkustock);
        }

        // GET: MizzaToppingSkustocks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingSkustock = await _context.MizzaToppingSkustocks
                .Include(m => m.MizzaToppingsStyleSku)
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingSkustock == null)
            {
                return NotFound();
            }

            return View(mizzaToppingSkustock);
        }

        // POST: MizzaToppingSkustocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaToppingSkustock = await _context.MizzaToppingSkustocks.FindAsync(id);
            _context.MizzaToppingSkustocks.Remove(mizzaToppingSkustock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaToppingSkustockExists(string id)
        {
            return _context.MizzaToppingSkustocks.Any(e => e.ToppingStyleId == id);
        }
    }
}
