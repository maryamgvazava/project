// Pages/Trains/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;

namespace WebApplication3.Pages.Trains
{
    public class IndexModel : PageModel
    {
        private readonly IRailwayService _railwayService;

        // Add this property
        public List<Train> Trains { get; set; } = new();

        public IndexModel(IRailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        public async Task<IActionResult> OnGetAsync(string from, string to, DateTime date)
        {
            var departures = await _railwayService.GetDeparturesAsync(from, to, date);
            Trains = departures.SelectMany(d => d.Trains).ToList();
            return Page();
        }
    }
}