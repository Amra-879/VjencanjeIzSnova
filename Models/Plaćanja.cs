using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Plaćanja
{
    public int PaymentId { get; set; }

    public int? ClientId { get; set; }

    public decimal Iznos { get; set; }

    public DateTime PlacanjeDatum { get; set; }

    public string? TransakcijaId { get; set; }

    public virtual Klijent? Client { get; set; }
}
