using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VjencanjeIzSnova_July.Models;

public partial class Usluge
{
    [Key]
    public int UslugaId { get; set; }
    [Required]
    public int PartnerId { get; set; }
    [Required]
    public string Naziv { get; set; } = null!;
    [Required]
    public int? KategorijaId { get; set; }

    public virtual Kategorije Kategorija { get; set; }

    public string? OpisUsluge { get; set; }

    public string? CjenovniRang { get; set; }
    [Required]
    public string InfoOKompaniji { get; set; }
    [Required]
    public string Detalji { get; set; }
    [EmailAddress]
    [Required]
    public string KontaktMail { get; set; }
    public virtual Partner? Partner { get; set; }
    public virtual ICollection<Slike> Slike { get; set; }
    public virtual ICollection<Rezervacije> Rezervacije { get; set; } = new List<Rezervacije>(); 
}

