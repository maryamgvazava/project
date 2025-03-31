using WebApplication3.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public interface IRailwayService
    {
        Task<List<Departure>> GetDeparturesAsync(string from, string to, string date);
        Task<Train> GetTrainDetailsAsync(int id);
        Task<string> CreateTicketAsync(TicketRequest request);
        Task<TicketResponse> GetTicketAsync(Guid ticketId);
        Task<bool> CancelTicketAsync(Guid ticketId);
        Task<List<Vagon>> GetVagon(int departureid);
    }
}