using System.ComponentModel.DataAnnotations;

namespace SeznamUkonu.Models
{
	public class SeznamCinnosti
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Prosím vyplňte")]
		public string Kdy { get; set; } = "";
		[Required(ErrorMessage = "Prosím vyplňte")]
		public string JmenoCinnosti { get; set; } = "";
		public string Podrobnosti { get; set; } = "";
	}
}
