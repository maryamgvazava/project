using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ApiModels;
using WebApplication3.Services;

public class TicketController : Controller
{
    private readonly RailwayService _railwayService;
    private readonly PDFService _pdfService;

    public TicketController(RailwayService railwayService, PDFService pdfService)
    {
        _railwayService = railwayService;
        _pdfService = pdfService;
    }

    [HttpPost]
    public async Task<IActionResult> CheckTicket(Guid ticketId)
    {
        var ticket = await _railwayService.GetTicketAsync(ticketId);
        return View("Details", ticket);
    }

    [HttpPost]
    public async Task<IActionResult> CancelTicket(Guid ticketId)
    {
        var success = await _railwayService.CancelTicketAsync(ticketId);
        return View("CancelResult", success);
    }
}