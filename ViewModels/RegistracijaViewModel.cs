using System.ComponentModel.DataAnnotations;
using VjencanjeIzSnova_July.Models;

namespace VjencanjeIzSnova_July.ViewModels
{
       public class RegistracijaViewModel
        {
            [Required]
            [EmailAddress]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email adresa")]
            public string Email { get; set; } = null;

        [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Lozinka")]
            public string Password { get; set; } = null;

        [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Potvrdite lozinku")]
            [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Tip korisnika")] 
            public string UserType { get; set; } = "Klijent";

            [Required]
            [Display(Name = "Ime")]
            public string Ime { get; set; } = null;

        [Required]
            [Display(Name = "Prezime")] 
            public string Prezime { get; set; } = null;

        [Required]
            [Display(Name = "Grad")]
            public string Grad { get; set; } = null;

        [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Datum vjenčanja")]
            public DateOnly DatumVjencanja { get; set; } 
    }
    }


