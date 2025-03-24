namespace WebApplication3.Models.ViewModels
{
    public class BookingViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<PassengerViewModel> Passengers { get; set; } = new();
        public Guid SelectedSeatId { get; set; }
    }
}