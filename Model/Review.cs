using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DoAnLapTrinhWeb.Model
{
	public class Review
	{
		[Key]
		public string PreviewId { get; set; }
		public string ServiceId { get; set; }

		public virtual Service Service { get; set; }
		public string UserId { get; set; }

		public virtual IdentityUser User { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
