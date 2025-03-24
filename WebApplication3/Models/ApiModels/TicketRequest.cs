using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class TicketRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("passengers")]
        public List<PassengerRequest> Passengers { get; set; } = new List<PassengerRequest>();
    }

    public class PassengerRequest
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("personalNumber")]
        public string PersonalNumber { get; set; } = string.Empty;

        [JsonPropertyName("seatId")]
        public Guid SeatId { get; set; }
    }
}