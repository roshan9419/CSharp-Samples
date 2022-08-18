using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MizzaToppingsCore.DataModel.Models;

namespace MizzaApp.MVCCore.Controllers
{
    public class MizzaToppingSkupricesController : Controller
    {
        private readonly MizzaToppingContext _context;

        public MizzaToppingSkupricesController(MizzaToppingContext context)
        {
            _context = context;
        }

        // GET: MizzaToppingSkuprices
        public async Task<IActionResult> Index()
        {
            var mizzaToppingContext = _context.MizzaToppingSkuprices.Include(m => m.MizzaToppingsStyleSku);
            return View(await mizzaToppingContext.ToListAsync());
        }

        // GET: MizzaToppingSkuprices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingSkuprice = await _context.MizzaToppingSkuprices
                .Include(m => m.MizzaToppingsStyleSku)
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingSkuprice == null)
            {
                return NotFound();
            }

            return View(mizzaToppingSkuprice);
        }

        // GET: MizzaToppingSkuprices/Create
        public IActionResult Create()
        {
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId");
            return View();
        }

        // POST: MizzaToppingSkuprices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToppingStyleId,Skuid,Price")] MizzaToppingSkuprice mizzaToppingSkuprice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaToppingSkuprice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId", mizzaToppingSkuprice.ToppingStyleId);
            return View(mizzaToppingSkuprice);
        }

        // GET: MizzaToppingSkuprices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingSkuprice = await _context.MizzaToppingSkuprices.FindAsync(id);
            if (mizzaToppingSkuprice == null)
            {
                return NotFound();
            }
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId", mizzaToppingSkuprice.ToppingStyleId);
            return View(mizzaToppingSkuprice);
        }

        // POST: MizzaToppingSkuprices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ToppingStyleId,Skuid,Price")] MizzaToppingSkuprice mizzaToppingSkuprice)
        {
            if (id != mizzaToppingSkuprice.ToppingStyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaToppingSkuprice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaToppingSkupriceExists(mizzaToppingSkuprice.ToppingStyleId))
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
            ViewData["ToppingStyleId"] = new SelectList(_context.MizzaToppingsStyleSkus, "ToppingStyleId", "ToppingStyleId", mizzaToppingSkuprice.ToppingStyleId);
            return View(mizzaToppingSkuprice);
        }

        // GET: MizzaToppingSkuprices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaToppingSkuprice = await _context.MizzaToppingSkuprices
                .Include(m => m.MizzaToppingsStyleSku)
                .FirstOrDefaultAsync(m => m.ToppingStyleId == id);
            if (mizzaToppingSkuprice == null)
            {
                return NotFound();
            }

            return View(mizzaToppingSkuprice);
        }

        // POST: MizzaToppingSkuprices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaToppingSkuprice = await _context.MizzaToppingSkuprices.FindAsync(id);
            _context.MizzaToppingSkuprices.Remove(mizzaToppingSkuprice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaToppingSkupriceExists(string id)
        {
            return _context.MizzaToppingSkuprices.Any(e => e.ToppingStyleId == id);
        }
    }
}
