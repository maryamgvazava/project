using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;

namespace WebApplication3.Pages.Passengers
{
    public class IndexModel : PageModel
    {

        private readonly RailwayService _railwayService;

        [BindProperty(SupportsGet = true)]
        public int TrainId { get; set; }

        public WebApplication3.Models.ApiModels.Train? Train { get; set; }
        // Constructor
        public IndexModel(RailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        // This is where OnGetAsync should be declared
        public async Task<IActionResult> OnGetAsync()
        {
            Train = await _railwayService.GetTrainDetailsAsync(TrainId);

            if (Train is null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}