using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.ApiModels;
using WebApplication3.Models.ViewModels;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRailwayService _railwayService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IRailwayService railwayService,
            ILogger<HomeController> logger)
        {
            _railwayService = railwayService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index", model);

                var departures = await _railwayService.GetDeparturesAsync(
                    model.FromCity,
                    model.ToCity,
                    model.TravelDate
                );

                return View("SearchResults", departures);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Search failed");
                return RedirectToAction("Error");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = HttpContext.TraceIdentifier
            });
        }
    }
}