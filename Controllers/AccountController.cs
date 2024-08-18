using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VjencanjeIzSnova_July.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VjencanjeIzSnova_July.ViewModels;
using VjencanjeIzSnova_July.Data;


namespace VjencanjeIzSnova_July.Controllers
{
    public class AccountController : Controller

    {
        private readonly VjencanjeIzSnovaDbContext _context;
        private readonly UserManager<Korisnici> _userManager;
        private readonly SignInManager<Korisnici> _signInManager;

        public AccountController(UserManager<Korisnici> userManager, SignInManager<Korisnici> signInManager, VjencanjeIzSnovaDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        } 

      
        /*[HttpGet]
        [Route("registracija")]
        public IActionResult Registracija()
        {
            ViewData["Title"] = "Registracija";
            return View(new RegisterViewModel());
        }

        [HttpPost]
        */

        [HttpGet]
       // [Route("registracija")]
        public IActionResult Registracija()
        {
            ViewData["Title"] = "Registracijaa";
            return View();
        }

        /*[HttpPost]
        //[Route("registracija")]
        public IActionResult Registracija(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle registration logic here
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        } */

        public async Task<IActionResult> Registracija(RegistracijaViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var user = new Korisnici 
                { 
                    UserName = model.Email,
                    Email = model.Email, 
                    UserType = model.UserType,
                    Password = model.Password
                };

                var klijent = new Klijent
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Grad = model.Grad,
                    DatumVjenčanja = model.DatumVjencanja

                };

                var result = await _userManager.CreateAsync(user);
                
                if (result.Succeeded)
                {
                    _context.Korisnici.Add(user);
                    _context.Klijenti.Add(klijent);
                    await _context.SaveChangesAsync();
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        } 

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Neuspješan pokušaj prijave.");
            }
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}
