using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModels
{
    public class PassengerViewModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Personal number must be 11 digits")]
        public string PersonalNumber { get; set; } = string.Empty;

        public Guid SeatId { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public string VagonNumber { get; set; } = string.Empty;
    }
}