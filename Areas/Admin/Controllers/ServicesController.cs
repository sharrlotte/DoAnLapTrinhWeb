using DoAnLapTrinhWeb.Lib;
using DoAnLapTrinhWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnLapTrinhWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ServicesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public ServicesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: Admin/Services
		public async Task<IActionResult> Index()
		{
			return View(await _context.Services.Include(c => c.Category).Include(c => c.User).ToListAsync());
		}

		// GET: Admin/Services/Details/5
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

		// GET: Admin/Services/Create
		public async Task<IActionResult> Create()
		{
			var categories = await _context.Categories.ToListAsync();

			ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");

			return View();
		}

		// POST: Admin/Services/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Name,Description,DeliveryCount,TotalDeliveryTime,Like,CategoryId,UserId,Thumbnail")] Service service)
		{
			if (ModelState.IsValid)
			{
				var userId = _userManager.GetUserId(User);
				service.UserId = userId;
				if (service.Thumbnail != null)
				{
					var imageUrl = await Utils.SaveImage(service.Thumbnail);
					service.ThumbnailUrl = imageUrl;
				}
				_context.Add(service);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			var categories = await _context.Categories.ToListAsync();

			ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");

			return View(service);
		}

		// GET: Admin/Services/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var service = await _context.Services.FindAsync(id);


			if (service == null)
			{
				return NotFound();
			}

			var categories = await _context.Categories.ToListAsync();

			ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");

			return View(service);
		}

		// POST: Admin/Services/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("ServiceId,Name,Description,CategoryId,Thumbnail")] Service service)
		{
			if (id != service.ServiceId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var old = _context.Services.FirstOrDefault(c => c.ServiceId.Equals(id));

					if (service.Thumbnail != null)
					{
						var imageUrl = await Utils.SaveImage(service.Thumbnail);
						old.ThumbnailUrl = imageUrl;
					}


					old.CategoryId = service.CategoryId;
					old.Name = service.Name;
					old.Description = service.Description;


					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ServiceExists(service.ServiceId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			var categories = await _context.Categories.ToListAsync();

			ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");

			return View(service);
		}

		// GET: Admin/Services/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var service = await _context.Services
				.FirstOrDefaultAsync(m => m.ServiceId == id);
			if (service == null)
			{
				return NotFound();
			}

			return View(service);
		}

		// POST: Admin/Services/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			var service = await _context.Services.FindAsync(id);
			if (service != null)
			{
				_context.Services.Remove(service);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ServiceExists(string id)
		{
			return _context.Services.Any(e => e.ServiceId == id);
		}
	}
}
