using Microsoft.AspNetCore.Mvc;
using VjencanjeIzSnova_July.Models;
using VjencanjeIzSnova_July.ViewModels; 
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VjencanjeIzSnova_July.Data;

namespace VjencanjeIzSnova_July.Controllers
{
    public class PartnerController : Controller
    {
        private readonly VjencanjeIzSnovaDbContext _context;

        public PartnerController(VjencanjeIzSnovaDbContext context)
        {
            _context = context;
        }

        // GET: Partner/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreatePartnerViewModel
            {
                KategorijeList = await _context.Kategorije.ToListAsync()
            };

            return View(viewModel);
        }

        // POST: Partner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePartnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new user
                var korisnik = new Korisnici
                {
                    Email = model.Email,
                    Password = model.Password,
                    UserType = model.UserType
                };

                _context.Korisnici.Add(korisnik);
                await _context.SaveChangesAsync();

                // Create a new partner
                var partner = new Partner
                {
                    UserId = korisnik.UserId,
                    Ime = model.Ime,
                    Mobitel = model.Mobitel,
                    KategorijaId = model.KategorijaId
                };

                _context.Partneri.Add(partner);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirect to a different action/view
            }

            // If model state is invalid, reload categories and return view with the model
            model.KategorijeList = await _context.Kategorije.ToListAsync();
            return View(model);
        }
    }
}
