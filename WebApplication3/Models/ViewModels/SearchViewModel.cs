using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        public string FromCity { get; set; } = string.Empty;

        [Required]
        public string ToCity { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime TravelDate { get; set; } = DateTime.Today;
    }
}