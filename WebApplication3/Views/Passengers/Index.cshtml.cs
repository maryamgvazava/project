using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels;
using WebApplication3.Models.ViewModels;
using WebApplication3.Services;

namespace WebApplication3.Pages.Passengers
{
    public class IndexModel : PageModel
    {
        private readonly IRailwayService _railwayService;

        [BindProperty(SupportsGet = true)]
        public int TrainId { get; set; }

        public Models.ApiModels.Train? TrainDetails { get; set; }

        [BindProperty]
        public BookingViewModel Booking { get; set; } = new();

        public IndexModel(IRailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            TrainDetails = await _railwayService.GetTrainDetailsAsync(TrainId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TrainDetails = await _railwayService.GetTrainDetailsAsync(TrainId);
                return Page();
            }
            return RedirectToPage("/Payment/Index", new { TrainId });
        }
    }
}