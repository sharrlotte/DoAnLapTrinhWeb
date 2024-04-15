using DoAnLapTrinhWeb.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnLapTrinhWeb.Controllers
{
	public class ServicesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public ServicesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Services.Include(c => c.Category).Include(c => c.User).ToListAsync());
		}

		public async Task<IActionResult> Details(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var service = await _context.Services
				.Include(c => c.Category)
				.FirstOrDefaultAsync(m => m.ServiceId == id);

			if (service == null)
			{
				return NotFound();
			}

			return View(service);
		}
	}
}
