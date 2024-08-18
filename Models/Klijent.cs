using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Klijent
{
    public int KlijentId { get; set; }

    public string UserId { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string? Grad { get; set; }

    public DateOnly? DatumVjenčanja { get; set; }

    public virtual ICollection<Košarica> Košarica { get; set; } = new List<Košarica>();

    public virtual ICollection<Plaćanja> Plaćanja { get; set; } = new List<Plaćanja>();

    public virtual ICollection<Recenzije> Recenzije { get; set; } = new List<Recenzije>();

    public virtual ICollection<Rezervacije> Rezervacije { get; set; } = new List<Rezervacije>();

    public virtual Korisnici User { get; set; } = null!;

    public virtual ICollection<Planer> Planer { get; set; } = new List<Planer>();
}
