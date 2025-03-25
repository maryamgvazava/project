using System.ComponentModel.DataAnnotations;
using WebApplication3.Models.ApiModels; // Add this

namespace WebApplication3.Models.ViewModels
{
    public class PaymentViewModel
    {
        [Required]
        [CreditCard]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$")]
        public string Expiry { get; set; } = string.Empty;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string CVV { get; set; } = string.Empty;

        public TicketRequest TicketRequest { get; set; } = new();
    }
}