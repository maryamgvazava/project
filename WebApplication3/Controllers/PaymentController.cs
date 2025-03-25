using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ApiModels;
using WebApplication3.Models.ViewModels;
using WebApplication3.Services; // Add this

namespace WebApplication3.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IRailwayService _railwayService;
        private readonly IPDFService _pdfService; // Now recognizes IPDFService

        public PaymentController(IRailwayService railwayService, IPDFService pdfService)
        {
            _railwayService = railwayService;
            _pdfService = pdfService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentViewModel model)
        {
            if (!ModelState.IsValid) return View("PaymentForm", model);

            try
            {
                var ticketResponse = await _railwayService.CreateTicketAsync(model.TicketRequest);
                return RedirectToAction("Confirmation", new { ticketId = ticketResponse.Id });
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Confirmation(Guid ticketId)
        {
            return View(ticketId);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTicket(Guid ticketId)
        {
            var ticket = await _railwayService.GetTicketAsync(ticketId);
            var pdfBytes = _pdfService.GenerateTicketPdf(ticket);
            return File(pdfBytes, "application/pdf", $"Ticket-{ticketId}.pdf");
        }
    }
}