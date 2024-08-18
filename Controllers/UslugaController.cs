using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using NuGet.Protocol;
using VjencanjeIzSnova_July.Data;
using VjencanjeIzSnova_July.Models;
using VjencanjeIzSnova_July.ViewModels;

namespace VjencanjeIzSnova_July.Controllers
{
    public class UslugaController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UslugaController(VjencanjeIzSnovaDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Usluga
        public async Task<IActionResult> Index()
        {
            var vjencanjeIzSnovaDbContext = _context.Usluge.Include(u => u.Partner).Include(u => u.Slike);
            return View(await vjencanjeIzSnovaDbContext.ToListAsync());
        }

        // GET: Usluga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluge = await _context.Usluge
                .Include(u => u.Partner)
                .Include(u => u.Slike) // Include images
                .FirstOrDefaultAsync(m => m.UslugaId == id);
            if (usluge == null)
            {
                return NotFound();
            }

            return View(usluge);
        }

        // GET: Usluga/Create
        public async Task<IActionResult> CreateAsync()
        {
            var viewModel = new UslugaViewModel
            {
                KategorijeList = await _context.Kategorije.ToListAsync()
            };
            ViewData["PartnerId"] = new SelectList(_context.Partneri, "PartnerId", "PartnerId");
            return View(viewModel);
        }

        // POST: Usluga/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UslugaViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kreiraj i sprimi Usluge entitet
                var usluge = new Usluge
                {
                    PartnerId = model.PartnerId,
                    Naziv = model.Naziv,
                    OpisUsluge = model.OpisUsluge,
                    CjenovniRang = model.CjenovniRang,
                    InfoOKompaniji = model.InfoOKompaniji,
                    Detalji = string.Join(", ", Request.Form["Detalji[]"]),
                    KategorijaId = model.KategorijaId
                };

                _context.Usluge.Add(usluge);
                await _context.SaveChangesAsync();

                // za upload slika
                /*if (model.Slike != null && model.Slike.Any())
                {
                    //string folder = "/slike/Usluge";
                    //string serverFolder = Path.Combine(_hostingEnvironment.WebRootPath, folder);
                    
                    foreach (var file in model.Slike)
                    {
                        if (file.Length > 0)
                        {

                            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            //string folder = "/slike/Usluge";
                            //folder += UslugaViewModel.Slike.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "slike", fileName);

                            // Sačuvaj file na server
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            // Kreiraj i sačuvaj Slike entitet
                            var slika = new Slike
                            {
                                Url = fileName,
                                UslugaId = usluge.UslugaId
                            };
                            _context.Slike.Add(slika);
                        }
                    }
                    await _context.SaveChangesAsync();
                */

                return RedirectToAction(nameof(Index));
            }

            // Repopulate ViewData if ModelState is invalid
            ViewData["PartnerId"] = new SelectList(_context.Partneri, "PartnerId", "PartnerId", model.PartnerId);
            return View(model);
        }


        // GET: Usluga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluge = await _context.Usluge.FindAsync(id);
            if (usluge == null)
            {
                return NotFound();
            }
            ViewData["PartnerId"] = new SelectList(_context.Partneri, "PartnerId", "PartnerId", usluge.PartnerId);
            return View(usluge);
        }

        // POST: Usluga/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UslugaId,PartnerId,Naziv,OpisUsluge,CjenovniRang,InfoOKompaniji,Detalji")] Usluge usluge)
        {
            if (id != usluge.UslugaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usluge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugeExists(usluge.UslugaId))
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
            ViewData["PartnerId"] = new SelectList(_context.Partneri, "PartnerId", "PartnerId", usluge.PartnerId);
            return View(usluge);
        }

        // GET: Usluga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluge = await _context.Usluge
                .Include(u => u.Partner)
                .Include(u => u.Slike) // Include images
                .FirstOrDefaultAsync(m => m.UslugaId == id);
            if (usluge == null)
            {
                return NotFound();
            }

            return View(usluge);
        }

        // POST: Usluga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usluge = await _context.Usluge.FindAsync(id);
            if (usluge != null)
            {
                _context.Usluge.Remove(usluge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugeExists(int id)
        {
            return _context.Usluge.Any(e => e.UslugaId == id);
        }
    }
}
