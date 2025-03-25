// Pages/Trains/Details.cshtml.cs
using Microsoft.AspNetCore.Mvc; // Add this
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;

namespace WebApplication3.Pages.Trains
{
    public class DetailsModel : PageModel
    {
        private readonly IRailwayService _railwayService;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Train? Train { get; set; }

        public DetailsModel(IRailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Train = await _railwayService.GetTrainDetailsAsync(Id);
            return Page();
        }
    }
}