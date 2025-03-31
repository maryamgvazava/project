using WebApplication3.Models.ApiModels;

namespace WebApplication3.Services
{
    public interface IStationService
    {
        Task<List<Station>> GetStationsAsync();
    }
}
