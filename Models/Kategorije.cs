using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Kategorije
{
    public int KategorijaId { get; set; }

    public string Naziv { get; set; } = null!;

    public string? Opis { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
