using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class Train
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("from")]
        public string From { get; set; } = string.Empty;

        [JsonPropertyName("to")]
        public string To { get; set; } = string.Empty;

        [JsonPropertyName("departure")]
        public string DepartureTime { get; set; } = string.Empty;

        [JsonPropertyName("arrive")]
        public string ArrivalTime { get; set; } = string.Empty;

        [JsonPropertyName("vagons")]
        public List<Vagon> Vagons { get; set; } = new List<Vagon>();
    }
}