using Microsoft.AspNetCore.Identity;

namespace DoAnLapTrinhWeb.Model
{
	public class Comment
	{
		public string CommentId { get; set; }

		public string Content { get; set; }

		public string UserId { get; set; }

		public IdentityUser User { get; set; }

		public string ServiceId { get; set; }

		public Service Service { get; set; }

		public string CreatedAt { get; set; }

		public bool IsDeleted { get; set; }
	}
}
