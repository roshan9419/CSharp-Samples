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
    public class MizzaSkuBasePricesController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaSkuBasePricesController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaSkuBasePrices
        public async Task<IActionResult> Index()
        {
            var mIzzaNextContext = _context.MizzaSkuBasePrices.Include(m => m.Sku);
            return View(await mIzzaNextContext.ToListAsync());
        }

        // GET: MizzaSkuBasePrices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSkuBasePrice = await _context.MizzaSkuBasePrices
                .Include(m => m.Sku)
                .FirstOrDefaultAsync(m => m.Skuid == id);
            if (mizzaSkuBasePrice == null)
            {
                return NotFound();
            }

            return View(mizzaSkuBasePrice);
        }

        // GET: MizzaSkuBasePrices/Create
        public IActionResult Create()
        {
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid");
            return View();
        }

        // POST: MizzaSkuBasePrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Skuid,Price")] MizzaSkuBasePrice mizzaSkuBasePrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaSkuBasePrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid", mizzaSkuBasePrice.Skuid);
            return View(mizzaSkuBasePrice);
        }

        // GET: MizzaSkuBasePrices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSkuBasePrice = await _context.MizzaSkuBasePrices.FindAsync(id);
            if (mizzaSkuBasePrice == null)
            {
                return NotFound();
            }
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid", mizzaSkuBasePrice.Skuid);
            return View(mizzaSkuBasePrice);
        }

        // POST: MizzaSkuBasePrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Skuid,Price")] MizzaSkuBasePrice mizzaSkuBasePrice)
        {
            if (id != mizzaSkuBasePrice.Skuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaSkuBasePrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaSkuBasePriceExists(mizzaSkuBasePrice.Skuid))
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
            ViewData["Skuid"] = new SelectList(_context.MizzaSkus, "MizzaSkuid", "MizzaSkuid", mizzaSkuBasePrice.Skuid);
            return View(mizzaSkuBasePrice);
        }

        // GET: MizzaSkuBasePrices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSkuBasePrice = await _context.MizzaSkuBasePrices
                .Include(m => m.Sku)
                .FirstOrDefaultAsync(m => m.Skuid == id);
            if (mizzaSkuBasePrice == null)
            {
                return NotFound();
            }

            return View(mizzaSkuBasePrice);
        }

        // POST: MizzaSkuBasePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaSkuBasePrice = await _context.MizzaSkuBasePrices.FindAsync(id);
            _context.MizzaSkuBasePrices.Remove(mizzaSkuBasePrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaSkuBasePriceExists(string id)
        {
            return _context.MizzaSkuBasePrices.Any(e => e.Skuid == id);
        }
    }
}
