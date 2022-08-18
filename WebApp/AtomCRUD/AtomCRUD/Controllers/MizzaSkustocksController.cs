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
    public class MizzaSkustocksController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaSkustocksController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaSkustocks
        public async Task<IActionResult> Index()
        {
            var mIzzaNextContext = _context.MizzaSkustocks.Include(m => m.Sku);
            return View(await mIzzaNextContext.ToListAsync());
        }

        // GET: MizzaSkustocks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSkustock = await _context.MizzaSkustocks
                .Include(m => m.Sku)
                .FirstOrDefaultAsync(m => m.Skuid == id);
            if (mizzaSkustock == null)
            {
                return NotFound();
            }

            return View(mizzaSkustock);
        }

        // GET: MizzaSkustocks/Create
        public IActionResult Create()
        {
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid");
            return View();
        }

        // POST: MizzaSkustocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Skuid,StockCount")] MizzaSkustock mizzaSkustock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaSkustock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid", mizzaSkustock.Skuid);
            return View(mizzaSkustock);
        }

        // GET: MizzaSkustocks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSkustock = await _context.MizzaSkustocks.FindAsync(id);
            if (mizzaSkustock == null)
            {
                return NotFound();
            }
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid", mizzaSkustock.Skuid);
            return View(mizzaSkustock);
        }

        // POST: MizzaSkustocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Skuid,StockCount")] MizzaSkustock mizzaSkustock)
        {
            if (id != mizzaSkustock.Skuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaSkustock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaSkustockExists(mizzaSkustock.Skuid))
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
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid", mizzaSkustock.Skuid);
            return View(mizzaSkustock);
        }

        // GET: MizzaSkustocks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSkustock = await _context.MizzaSkustocks
                .Include(m => m.Sku)
                .FirstOrDefaultAsync(m => m.Skuid == id);
            if (mizzaSkustock == null)
            {
                return NotFound();
            }

            return View(mizzaSkustock);
        }

        // POST: MizzaSkustocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaSkustock = await _context.MizzaSkustocks.FindAsync(id);
            _context.MizzaSkustocks.Remove(mizzaSkustock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaSkustockExists(string id)
        {
            return _context.MizzaSkustocks.Any(e => e.Skuid == id);
        }
    }
}
