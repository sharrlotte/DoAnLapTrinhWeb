using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoAnLapTrinhWeb.Model
{
	public class ApplicationDbContext : IdentityDbContext

	{
		// Public 
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }

		public DbSet<Service> Services { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Favourite> Favourites { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<Price> Prices { get; set; }

		public DbSet<Review> Reviews { get; set; }

		public DbSet<Tag> Tags { get; set; }
	}
}
