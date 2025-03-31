using WebApplication3.Models.ApiModels;

namespace WebApplication3.Services
{
    public class StationsService:IStationService
    {
        private readonly HttpClient _httpClient;

        public StationsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://railway.stepprojects.ge/");
        }
        public async Task<List<Station>> GetStationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Station>>("api/stations");
            return response;
        }
    }
}
