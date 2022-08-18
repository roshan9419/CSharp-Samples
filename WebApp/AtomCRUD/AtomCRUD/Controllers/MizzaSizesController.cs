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
    public class MizzaSizesController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaSizesController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaSizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MizzaSizes.Take(10).ToListAsync());
        }

        // GET: MizzaSizes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSize = await _context.MizzaSizes
                .FirstOrDefaultAsync(m => m.MizzaSizeId == id);
            if (mizzaSize == null)
            {
                return NotFound();
            }

            return View(mizzaSize);
        }

        // GET: MizzaSizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MizzaSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MizzaSizeName,MizzaSizeId")] MizzaSize mizzaSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mizzaSize);
        }

        // GET: MizzaSizes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSize = await _context.MizzaSizes.FindAsync(id);
            if (mizzaSize == null)
            {
                return NotFound();
            }
            return View(mizzaSize);
        }

        // POST: MizzaSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MizzaSizeName,MizzaSizeId")] MizzaSize mizzaSize)
        {
            if (id != mizzaSize.MizzaSizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaSizeExists(mizzaSize.MizzaSizeId))
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
            return View(mizzaSize);
        }

        // GET: MizzaSizes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaSize = await _context.MizzaSizes
                .FirstOrDefaultAsync(m => m.MizzaSizeId == id);
            if (mizzaSize == null)
            {
                return NotFound();
            }

            return View(mizzaSize);
        }

        // POST: MizzaSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaSize = await _context.MizzaSizes.FindAsync(id);
            _context.MizzaSizes.Remove(mizzaSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaSizeExists(string id)
        {
            return _context.MizzaSizes.Any(e => e.MizzaSizeId == id);
        }
    }
}
