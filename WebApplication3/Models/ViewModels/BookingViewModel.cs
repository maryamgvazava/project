// Models/ViewModels/BookingViewModel.cs
using System.ComponentModel.DataAnnotations; // Add this
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Models.ViewModels
{
    public class BookingViewModel
    {
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [BindProperty]
        public List<PassengerViewModel> Passengers { get; set; } = new();
    }
}