using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class TicketController : Controller
    {
        private readonly IRailwayService _railwayService;

        public TicketController(IRailwayService railwayService)
        {
            _railwayService = railwayService;
        }

        public IActionResult Check()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckTicket(Guid ticketId)
        {
            try
            {
                var ticket = await _railwayService.GetTicketAsync(ticketId);
                return View("TicketStatus", ticket);
            }
            catch
            {
                ViewBag.Error = "Ticket not found";
                return View("Check");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CancelTicket(Guid ticketId)
        {
            var success = await _railwayService.CancelTicketAsync(ticketId);
            return View("CancelResult", success);
        }
    }
}
