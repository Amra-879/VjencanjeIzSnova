using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VjencanjeIzSnova_July.Data;
using VjencanjeIzSnova_July.Models;

namespace VjencanjeIzSnova_July.Controllers
{
    public class KategorijeController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;

        public KategorijeController(VjencanjeIzSnovaDbContext context)
        {
            _context = context;
        }

        // GET: Kategorije
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategorije.ToListAsync());
        }

        // GET: Kategorije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorije = await _context.Kategorije
                .FirstOrDefaultAsync(m => m.KategorijaId == id);
            if (kategorije == null)
            {
                return NotFound();
            }

            return View(kategorije);
        }

        // GET: Kategorije/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategorije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategorijaId,Naziv,Opis")] Kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategorije);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategorije);
        }

        // GET: Kategorije/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorije = await _context.Kategorije.FindAsync(id);
            if (kategorije == null)
            {
                return NotFound();
            }
            return View(kategorije);
        }

        // POST: Kategorije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategorijaId,Naziv,Opis")] Kategorije kategorije)
        {
            if (id != kategorije.KategorijaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorije);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorijeExists(kategorije.KategorijaId))
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
            return View(kategorije);
        }

        // GET: Kategorije/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorije = await _context.Kategorije
                .FirstOrDefaultAsync(m => m.KategorijaId == id);
            if (kategorije == null)
            {
                return NotFound();
            }

            return View(kategorije);
        }

        // POST: Kategorije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategorije = await _context.Kategorije.FindAsync(id);
            if (kategorije != null)
            {
                _context.Kategorije.Remove(kategorije);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorijeExists(int id)
        {
            return _context.Kategorije.Any(e => e.KategorijaId == id);
        }
    }
}
