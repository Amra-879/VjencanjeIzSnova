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
    public class PartneriController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;

        public PartneriController(VjencanjeIzSnovaDbContext context)
        {
            _context = context;
        }

        // GET: Partneri
        public async Task<IActionResult> Index()
        {
            var vjencanjeIzSnovaDbContext = _context.Partneri.Include(p => p.Kategorija).Include(p => p.User);
            return View(await vjencanjeIzSnovaDbContext.ToListAsync());
        }

        // GET: Partneri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partneri
                .Include(p => p.Kategorija)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PartnerId == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Partneri/Create
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "KategorijaId");
            //ViewData["UserId"] = new SelectList(_context.Korisnici, "UserId", "UserId");

            return View();
        }

        // POST: Partneri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartnerId,UserId,Ime,Mobitel,KategorijaId")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "KategorijaId", partner.KategorijaId);
            ViewData["UserId"] = new SelectList(_context.Korisnici, "UserId", "UserId", partner.UserId);
            return View(partner);
        }

        // GET: Partneri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partneri.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "KategorijaId", partner.KategorijaId);
            ViewData["UserId"] = new SelectList(_context.Korisnici, "UserId", "UserId", partner.UserId);
            return View(partner);
        }

        // POST: Partneri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartnerId,UserId,Ime,Mobitel,KategorijaId")] Partner partner)
        {
            if (id != partner.PartnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.PartnerId))
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
            ViewData["KategorijaId"] = new SelectList(_context.Kategorije, "KategorijaId", "KategorijaId", partner.KategorijaId);
            ViewData["UserId"] = new SelectList(_context.Korisnici, "UserId", "UserId", partner.UserId);
            return View(partner);
        }

        // GET: Partneri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partneri
                .Include(p => p.Kategorija)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PartnerId == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partneri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partner = await _context.Partneri.FindAsync(id);
            if (partner != null)
            {
                _context.Partneri.Remove(partner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
            return _context.Partneri.Any(e => e.PartnerId == id);
        }
    }
}
