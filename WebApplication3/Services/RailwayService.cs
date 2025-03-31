using System.Net.Http.Json;
using WebApplication3.Models.ApiModels;

namespace WebApplication3.Services
{
    public class RailwayService : IRailwayService
    {
        private readonly HttpClient _httpClient;

        public RailwayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://railway.stepprojects.ge/");
        }

        public async Task<List<Departure>> GetDeparturesAsync(string from, string to, string date)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Departure>>(
                $"/api/getdeparture?from={from}&to={to}&date={date:yyyy-MM-dd}");
            return response ?? new List<Departure>();
        }
        public async Task<List<Vagon>> GetVagon(int departureid)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Vagon>>(
                $"api/getvagon/{departureid}");
            return response ?? new List<Vagon>();
        }
        // Implement other interface methods
        public async Task<Train> GetTrainDetailsAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Train>($"/api/trains/{id}") ?? new Train();

        public async Task<string> CreateTicketAsync(TicketRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/tickets/register", request);
            var responseContent = await response.Content.ReadAsStringAsync(); 
            return responseContent;
        }

        public async Task<TicketResponse> GetTicketAsync(Guid ticketId) =>
            await _httpClient.GetFromJsonAsync<TicketResponse>($"/api/tickets/checkstatus/{ticketId}")
            ?? new TicketResponse();

        public async Task<bool> CancelTicketAsync(Guid ticketId)
        {
            var response = await _httpClient.DeleteAsync($"/api/tickets/cancel/{ticketId}");
            return response.IsSuccessStatusCode;
        }
    }
}