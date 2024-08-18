using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Recenzije
{
    public int RecenzijaId { get; set; }

    public int? KlijentId { get; set; }

    public int? UslugaId { get; set; }

    public double? Ocjena { get; set; }

    public string? Komentar { get; set; }

    public DateOnly Datum { get; set; }

    public virtual Klijent? Client { get; set; }

    public virtual Partner? Partner { get; set; }
}
