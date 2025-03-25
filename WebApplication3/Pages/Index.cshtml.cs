using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels;
using WebApplication3.Models.ViewModels;
using WebApplication3.Services;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRailwayService _railwayService;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public SearchViewModel Search { get; set; } = new();

        public List<Departure> SearchResults { get; set; } = new();

        public IndexModel(IRailwayService railwayService, ILogger<IndexModel> logger)
        {
            _railwayService = railwayService;
            _logger = logger;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                SearchResults = await _railwayService.GetDeparturesAsync(
                    Search.FromCity,
                    Search.ToCity,
                    Search.TravelDate
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Search error");
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}