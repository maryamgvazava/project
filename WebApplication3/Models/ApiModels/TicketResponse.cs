using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class TicketResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("trainNumber")]  // Add this property
        public string TrainNumber { get; set; } = string.Empty;

        [JsonPropertyName("passengers")]
        public List<PassengerResponse> Passengers { get; set; } = new();

        public class PassengerResponse
        {
            [JsonPropertyName("firstName")]
            public string FirstName { get; set; } = string.Empty;

            [JsonPropertyName("lastName")]
            public string LastName { get; set; } = string.Empty;

            [JsonPropertyName("seatNumber")]
            public string SeatNumber { get; set; } = string.Empty;
        }
    }
}