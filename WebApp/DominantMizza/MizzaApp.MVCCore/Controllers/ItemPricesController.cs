using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MizzaPricesCore.DataModel.Models;

namespace MizzaApp.MVCCore.Controllers
{
    public class ItemPricesController : Controller
    {
        private readonly MizzaPriceContext _context;

        public ItemPricesController(MizzaPriceContext context)
        {
            _context = context;
        }

        // GET: ItemPrices
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemPrices.ToListAsync());
        }

        // GET: ItemPrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPrice = await _context.ItemPrices
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemPrice == null)
            {
                return NotFound();
            }

            return View(itemPrice);
        }

        // GET: ItemPrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,Price,PriceId")] ItemPrice itemPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemPrice);
        }

        // GET: ItemPrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPrice = await _context.ItemPrices.FindAsync(id);
            if (itemPrice == null)
            {
                return NotFound();
            }
            return View(itemPrice);
        }

        // POST: ItemPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Price,PriceId")] ItemPrice itemPrice)
        {
            if (id != itemPrice.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemPriceExists(itemPrice.ItemId))
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
            return View(itemPrice);
        }

        // GET: ItemPrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPrice = await _context.ItemPrices
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemPrice == null)
            {
                return NotFound();
            }

            return View(itemPrice);
        }

        // POST: ItemPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemPrice = await _context.ItemPrices.FindAsync(id);
            _context.ItemPrices.Remove(itemPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemPriceExists(int id)
        {
            return _context.ItemPrices.Any(e => e.ItemId == id);
        }
    }
}
