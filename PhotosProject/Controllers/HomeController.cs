using Microsoft.AspNetCore.Mvc;
using PhotosProject.Models;
using System.Diagnostics;

namespace PhotosProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhotoService _photoService;

        public HomeController(PhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 3)
        {
            var photos = await _photoService.GetPhotosAsync();

            var totalPhotos = photos.Count();

            var totalPages = (int)Math.Ceiling((double)totalPhotos / pageSize);

            page = Math.Max(1, Math.Min(page, totalPages));

            var paginatedPhotos = photos.Skip((page - 1) * pageSize).Take(pageSize);

            var viewModel = new PhotoViewModel
            {
                Photos = paginatedPhotos,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalPhotos = totalPhotos
            };

            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}