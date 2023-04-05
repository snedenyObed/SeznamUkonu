using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeznamUkonu.Data;
using SeznamUkonu.Models;

namespace SeznamUkonu.Controllers
{
	[Authorize(Roles = "admin")]
	public class SeznamCinnostiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeznamCinnostiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SeznamCinnosti
        [AllowAnonymous]
		public async Task<IActionResult> Index()
        {
              return _context.SeznamCinnosti != null ? 
                          View(await _context.SeznamCinnosti.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SeznamCinnosti'  is null.");
        }

        // GET: SeznamCinnosti/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SeznamCinnosti == null)
            {
                return NotFound();
            }

            var seznamCinnosti = await _context.SeznamCinnosti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seznamCinnosti == null)
            {
                return NotFound();
            }

            return View(seznamCinnosti);
        }

        // GET: SeznamCinnosti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeznamCinnosti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kdy,JmenoCinnosti,Podrobnosti")] SeznamCinnosti seznamCinnosti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seznamCinnosti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seznamCinnosti);
        }

        // GET: SeznamCinnosti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SeznamCinnosti == null)
            {
                return NotFound();
            }

            var seznamCinnosti = await _context.SeznamCinnosti.FindAsync(id);
            if (seznamCinnosti == null)
            {
                return NotFound();
            }
            return View(seznamCinnosti);
        }

        // POST: SeznamCinnosti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kdy,JmenoCinnosti,Podrobnosti")] SeznamCinnosti seznamCinnosti)
        {
            if (id != seznamCinnosti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seznamCinnosti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeznamCinnostiExists(seznamCinnosti.Id))
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
            return View(seznamCinnosti);
        }

        // GET: SeznamCinnosti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SeznamCinnosti == null)
            {
                return NotFound();
            }

            var seznamCinnosti = await _context.SeznamCinnosti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seznamCinnosti == null)
            {
                return NotFound();
            }

            return View(seznamCinnosti);
        }

        // POST: SeznamCinnosti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SeznamCinnosti == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SeznamCinnosti'  is null.");
            }
            var seznamCinnosti = await _context.SeznamCinnosti.FindAsync(id);
            if (seznamCinnosti != null)
            {
                _context.SeznamCinnosti.Remove(seznamCinnosti);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeznamCinnostiExists(int id)
        {
          return (_context.SeznamCinnosti?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
