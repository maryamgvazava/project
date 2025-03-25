using WebApplication3.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public interface IRailwayService
    {
        Task<List<Departure>> GetDeparturesAsync(string from, string to, DateTime date);
        Task<Train> GetTrainDetailsAsync(int id);
        Task<TicketResponse> CreateTicketAsync(TicketRequest request);
        Task<TicketResponse> GetTicketAsync(Guid ticketId);
        Task<bool> CancelTicketAsync(Guid ticketId);
    }
}