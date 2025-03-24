using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace WebApplication3.Models.ApiModels
{
    public class Train
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        // Add this property
        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("from")]
        public string From { get; set; } = string.Empty;

        [JsonPropertyName("to")]
        public string To { get; set; } = string.Empty;

        [JsonPropertyName("departureTime")]
        public DateTime DepartureTime { get; set; }

        [JsonPropertyName("arrivalTime")]
        public DateTime ArrivalTime { get; set; }

        [JsonPropertyName("vagons")]
        public List<Vagon> Vagons { get; set; } = new List<Vagon>();
    }
}