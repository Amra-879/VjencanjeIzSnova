using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Rezervacije
{
    public int RezervacijeId { get; set; }

    public int? ClientId { get; set; }

    public int? UslugaId { get; set; }

    public DateOnly Datum { get; set; }

    public string? Status { get; set; }

    public virtual Klijent? Client { get; set; }

    public virtual Usluge? Usluga { get; set; }
}
