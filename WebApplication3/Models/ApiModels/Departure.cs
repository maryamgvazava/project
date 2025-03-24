using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WebApplication3.Models.ApiModels
{
    public class Departure
    {
        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;

        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        [JsonPropertyName("trains")]
        public List<Train> Trains { get; set; } = new List<Train>();
    }
}