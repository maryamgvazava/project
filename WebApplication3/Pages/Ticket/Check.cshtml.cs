using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;

namespace WebApplication3.Pages.Ticket
{
    public class CheckModel : PageModel
    {
        private readonly IRailwayService _railwayService;

        [BindProperty]
        public Guid TicketId { get; set; }

        public TicketResponse? Ticket { get; set; }

        public CheckModel(IRailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (TicketId == Guid.Empty) return Page();

            Ticket = await _railwayService.GetTicketAsync(TicketId);
            return Page();
        }

        public async Task<IActionResult> OnPostCancelAsync()
        {
            var success = await _railwayService.CancelTicketAsync(TicketId);
            return RedirectToPage("./Check", new { success });
        }
    }
}