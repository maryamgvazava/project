using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;

namespace WebApplication3.Pages.Train
{
    public class DetailsModel : PageModel
    {
        private readonly RailwayService _railwayService;
        public WebApplication3.Models.ApiModels.Train? Train { get; set; }
        public DetailsModel(RailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Train = await _railwayService.GetTrainDetailsAsync(id);
            return Train == null ? RedirectToPage("/Error") : Page();
        }
    }
}