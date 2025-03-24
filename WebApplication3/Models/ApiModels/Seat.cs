using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class Seat
    {
        [JsonPropertyName("seatId")]
        public Guid SeatId { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;

        [JsonPropertyName("isOccupied")]
        public bool IsOccupied { get; set; }
    }
}