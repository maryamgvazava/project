using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ApiModels;
using WebApplication3.Models.ViewModels;
using WebApplication3.Services;

public class PaymentController : Controller
{
    private readonly RailwayService _railwayService;

    public PaymentController(RailwayService railwayService)
    {
        _railwayService = railwayService;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment(PaymentViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        var ticket = await _railwayService.CreateTicketAsync(model.TicketRequest);
        return RedirectToAction("Confirmation", new { ticketId = ticket.Id });
    }

    public IActionResult Confirmation(Guid ticketId)
    {
        return View(ticketId);
    }
}