using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels; // Namespace for Train model
using WebApplication3.Services;

namespace WebApplication3.Pages.Train
{
    public class IndexModel : PageModel
    {
        private readonly RailwayService _railwayService;

        // Property declaration
        public List<WebApplication3.Models.ApiModels.Train>? Trains { get; set; }

        public IndexModel(RailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        public async Task<IActionResult> OnGetAsync(string from, string to, DateTime date)
        {
            Trains = await _railwayService.GetTrainsAsync(from, to, date);
            return Page();
        }
    }
}