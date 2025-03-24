using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Pages.Payment
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public PaymentViewModel Payment { get; set; } = new PaymentViewModel();

        public void OnGet()
        {
        }
    }
}