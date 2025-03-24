using WebApplication3.Models.ApiModels;

namespace WebApplication3.Models.ViewModels
{
    public class PaymentViewModel
    {
        public TicketRequest TicketRequest { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}