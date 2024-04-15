
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnLapTrinhWeb.Model
{
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public string? CategoryId { get; set; }
		[StringLength(100)]

		public required string Name { get; set; }

		public string? ImageUrl { get; set; }
		[NotMapped]
		public IFormFile? Image { get; set; }
	}
}
