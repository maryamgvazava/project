
using System.Text.Json.Serialization;
using WebApplication3.Models.ApiModels;

public class TicketResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string date { get; set; }
    public int ticketPrice { get; set; }
    public int trainID { get; set; }
    public bool confirmed { get; set; }
    [JsonPropertyName("train")]
    public Train Train { get; set; }
    [JsonPropertyName("persons")]
    public Person[] Persons { get; set; }
}

public class Seat
{
    public string seatId { get; set; }
    public string number { get; set; }
    public int price { get; set; }
    public bool isOccupied { get; set; }
    public int vagonId { get; set; }
}

public class Person
{
    public int id { get; set; }
    public string ticketId { get; set; }
    public Seat seat { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("surname")]
    public string Surname { get; set; }
    public string idNumber { get; set; }
    public string status { get; set; }
    public bool payoutCompleted { get; set; }
}

