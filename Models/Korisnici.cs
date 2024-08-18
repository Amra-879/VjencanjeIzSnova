using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;
using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Korisnik : IdentityUser<int>
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string? ProfilnaSlikaUrl { get; set; }

    public virtual Klijent? Klijent { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual Planer? Planer { get; set; }


}
