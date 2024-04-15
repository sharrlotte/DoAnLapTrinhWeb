using Microsoft.AspNetCore.Identity;

namespace DoAnLapTrinhWeb.Model
{
	public class Favourite
	{
		public string FavouriteId { get; set; }
		public string UserId { get; set; }

		public IdentityUser User { get; set; }
		public string ServiceId { get; set; }

		public Service Service { get; set; }

	}
}
