using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class Departure
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;

        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("trains")]
        public List<Train> Trains { get; set; } = new List<Train>();
    }
}