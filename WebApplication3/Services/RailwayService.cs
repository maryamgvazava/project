using System.Net.Http.Json;
using WebApplication3.Models.ApiModels;

namespace WebApplication3.Services
{
    public class RailwayService
    {
        private readonly HttpClient _httpClient;

        public RailwayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://railway.stepprojects.ge/");
        }

        // 1. Search available trains
        public async Task<List<Train>> GetTrainsAsync(string from, string to, DateTime date)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Departure>(
                    $"/api/routes?startPoint={from}&endPoint={to}&date={date:yyyy-MM-dd}");

                return response?.Trains ?? new List<Train>();
            }
            catch
            {
                return new List<Train>();
            }
        }

        // 2. Get specific train details
        public async Task<Train?> GetTrainDetailsAsync(int trainId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Train>($"/api/trains/{trainId}");
            }
            catch
            {
                return null;
            }
        }

        // 3. Create new ticket
        public async Task<TicketResponse?> CreateTicketAsync(TicketRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/tickets", request);

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadFromJsonAsync<TicketResponse>();
            }
            catch
            {
                return null;
            }
        }

        // 4. Get existing ticket
        public async Task<TicketResponse?> GetTicketAsync(Guid ticketId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<TicketResponse>($"/api/tickets/{ticketId}");
            }
            catch
            {
                return null;
            }
        }

        // 5. Cancel ticket
        public async Task<bool> CancelTicketAsync(Guid ticketId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/tickets/{ticketId}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}