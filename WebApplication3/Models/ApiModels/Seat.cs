using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class Seat
    {
        [JsonPropertyName("seatId")]
        public Guid SeatId { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("isOccupied")]
        public bool IsOccupied { get; set; }

        [JsonPropertyName("vagonId")]
        public int VagonId { get; set; }
    }
}