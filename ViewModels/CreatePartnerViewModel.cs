using System.ComponentModel.DataAnnotations;
using VjencanjeIzSnova_July.Models;

namespace VjencanjeIzSnova_July.ViewModels
{
	public class CreatePartnerViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = null!;

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;

		[Required]
		public string UserType { get; set; } = null!;

		[Required]
		public string Ime { get; set; } = null!;

		public string? Mobitel { get; set; }

		[Required]
		public int KategorijaId { get; set; }

		public IEnumerable<Kategorije> KategorijeList { get; set; } = new List<Kategorije>();
	}
}
