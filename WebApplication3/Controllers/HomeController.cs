using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;
using WebApplication3.Models.ApiModels;


public class HomeController : Controller
{
    private readonly RailwayService _railwayService;

    public HomeController(RailwayService railwayService)
    {
        _railwayService = railwayService;
    }

    [HttpPost]
    public async Task<IActionResult> Search(string from, string to, DateTime date)
    {
        var routes = await _railwayService.GetTrainsAsync(from, to, date);
        return View("SearchResults", routes);
    }
}