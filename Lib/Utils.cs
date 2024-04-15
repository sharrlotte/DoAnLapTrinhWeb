
namespace DoAnLapTrinhWeb.Lib
{
	public static class Utils
	{

		private static List<String> validImageExtentions = ["png", "jpg", "jpeg", "webp"];
		public static async Task<string> SaveImage(IFormFile image)

		{

			if (!validImageExtentions.Any(ext => image.FileName.EndsWith(ext)))
			{
				throw new Exception("Invalid image format");
			}

			var uuid = Guid.NewGuid().ToString() + ".png";

			var savePath = Path.Combine("wwwroot/images", uuid); // Thay đổi đường dẫn theo cấu hình của bạn 

			if (!File.Exists(savePath))
			{
				Directory.CreateDirectory("wwwroot/images");
			}

			using (var fileStream = new FileStream(savePath, FileMode.Create))

			{

				await image.CopyToAsync(fileStream);

			}

			return "/images/" + uuid; // Trả về đường dẫn tương đối 

		}

		public static void DeleteImage(String path)
		{
			File.Delete(path);
		}

	}
}
