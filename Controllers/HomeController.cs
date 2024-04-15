using DoAnLapTrinhWeb.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnLapTrinhWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		private readonly UserManager<IdentityUser> _userManager;

		public HomeController(UserManager<IdentityUser> userManager, IServiceProvider serviceProvider, ApplicationDbContext context)
		{
			_userManager = userManager;

			Configure(serviceProvider);
			_context = context;
		}
		public void Configure(IServiceProvider serviceProvider)
		{
			CreateRoles(serviceProvider).Wait();
		}

		private async Task CreateRoles(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			string[] roleNames = { "User", "Admin" };
			foreach (var roleName in roleNames)
			{
				var roleExist = await roleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}
		}
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user != null)
			{
				await _userManager.AddToRoleAsync(user, "Admin");
			}

			var services = _context.Services.Take(10).Include(c => c.User).ToList();
			var categories = _context.Categories.Take(10).ToList();

			ViewBag.Categories = categories;
			ViewBag.Services = services;

			return View();
		}
	}
}
