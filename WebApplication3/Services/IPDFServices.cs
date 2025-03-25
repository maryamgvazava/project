using WebApplication3.Models.ApiModels;

namespace WebApplication3.Services
{
    public interface IPDFService
    {
        byte[] GenerateTicketPdf(TicketResponse? ticket);
    }
}