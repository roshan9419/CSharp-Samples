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
    public class MizzaStylesController : Controller
    {
        private readonly MIzzaNextContext _context;

        public MizzaStylesController(MIzzaNextContext context)
        {
            _context = context;
        }

        // GET: MizzaStyles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MizzaStyles.ToListAsync());
        }

        // GET: MizzaStyles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaStyle = await _context.MizzaStyles
                .FirstOrDefaultAsync(m => m.MizzaStyleId == id);
            if (mizzaStyle == null)
            {
                return NotFound();
            }

            return View(mizzaStyle);
        }

        // GET: MizzaStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MizzaStyles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MizzaStyleName,MizzaStyleId")] MizzaStyle mizzaStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mizzaStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mizzaStyle);
        }

        // GET: MizzaStyles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaStyle = await _context.MizzaStyles.FindAsync(id);
            if (mizzaStyle == null)
            {
                return NotFound();
            }
            return View(mizzaStyle);
        }

        // POST: MizzaStyles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MizzaStyleName,MizzaStyleId")] MizzaStyle mizzaStyle)
        {
            if (id != mizzaStyle.MizzaStyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mizzaStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MizzaStyleExists(mizzaStyle.MizzaStyleId))
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
            return View(mizzaStyle);
        }

        // GET: MizzaStyles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mizzaStyle = await _context.MizzaStyles
                .FirstOrDefaultAsync(m => m.MizzaStyleId == id);
            if (mizzaStyle == null)
            {
                return NotFound();
            }

            return View(mizzaStyle);
        }

        // POST: MizzaStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mizzaStyle = await _context.MizzaStyles.FindAsync(id);
            _context.MizzaStyles.Remove(mizzaStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MizzaStyleExists(string id)
        {
            return _context.MizzaStyles.Any(e => e.MizzaStyleId == id);
        }
    }
}
