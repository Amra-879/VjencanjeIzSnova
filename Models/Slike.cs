using System.ComponentModel.DataAnnotations;

namespace VjencanjeIzSnova_July.Models
{
    public class Slike
    {
        [Key]
        public int SlikaId { get; set; }
        public int UslugaId { get; set; }
        public string Url { get; set; }
        public virtual Usluge Usluga { get; set; }
    }
}
