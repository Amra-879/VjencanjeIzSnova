using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Partner
{
    public int PartnerId { get; set; }

    public int UserId { get; set; }

    public string Ime { get; set; } = null!;

    public string? Mobitel { get; set; }

    public int? KategorijaId { get; set; }

    public virtual Kategorije? Kategorija { get; set; }

    public virtual ICollection<Recenzije> Recenzija { get; set; } = new List<Recenzije>();

    public virtual Korisnici User { get; set; } = null!;

    public virtual ICollection<Usluge> Usluga { get; set; } = new List<Usluge>();
}
