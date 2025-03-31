using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.ApiModels;
using WebApplication3.Models.ViewModels;
using WebApplication3.Services; // Add this

namespace WebApplication3.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IRailwayService _railwayService;

        public PaymentController(IRailwayService railwayService)
        {
            _railwayService = railwayService;
        }


        [HttpGet]
        public IActionResult Confirmation(Guid ticketId)
        {
            return View(ticketId);
        }

      
    }
}