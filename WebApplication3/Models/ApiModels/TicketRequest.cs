using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication3.Models.ApiModels
{
    public class TicketRequest
    {
        [JsonPropertyName("trainId")]
        public int TrainId { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonPropertyName("people")]
        public List<PassengerRequest> People { get; set; } = new List<PassengerRequest>();

        public class PassengerRequest
        {
            [JsonPropertyName("seatId")]
            public Guid SeatId { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            [JsonPropertyName("surname")]
            public string Surname { get; set; } = string.Empty;

            [JsonPropertyName("idNumber")]
            public string IdNumber { get; set; } = string.Empty;

            public string Status { get; set; }
            public bool PayoutCompleted { get; set; }
        }
    }
}
