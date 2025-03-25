using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class TicketResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("train")]
        public Train? Train { get; set; }

        [JsonPropertyName("persons")]
        public List<PassengerResponse> Persons { get; set; } = new();

        public class PassengerResponse
        {
            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("surname")]
            public string? Surname { get; set; }

            [JsonPropertyName("seatNumber")]
            public string? SeatNumber { get; set; }

            [JsonPropertyName("idNumber")]
            public string? IdNumber { get; set; }
        }
    }
}