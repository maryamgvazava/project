﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class Vagon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("trainId")]
        public int TrainId { get; set; }
        [JsonPropertyName("trainNumber")]
        public int TrainNumber { get; set;} 

        [JsonPropertyName("seats")]
        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}