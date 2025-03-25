using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WebApplication3.Models.ApiModels;

namespace WebApplication3.Services
{
    public class PDFService : IPDFService
    {
        public byte[] GenerateTicketPdf(TicketResponse? ticket)
        {
            if (ticket == null) return Array.Empty<byte>();

            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre); // Added missing semicolon here

                    page.Header()
                        .AlignCenter()
                        .Text("Train Ticket")
                        .FontSize(20).Bold();

                    page.Content()
                        .PaddingVertical(10)
                        .Column(col =>
                        {
                            col.Item().Text($"Ticket ID: {ticket.Id}");
                            col.Item().Text($"Status: {ticket.Status ?? "Unknown"}");

                            if (ticket.Train != null)
                            {
                                col.Item().Text($"Train: {ticket.Train.Name} (#{ticket.Train.Number})");
                                col.Item().Text($"Route: {ticket.Train.From} → {ticket.Train.To}");
                                col.Item().Text($"Departure: {ticket.Train.DepartureTime}");
                            }

                            foreach (var passenger in ticket.Persons)
                            {
                                col.Item().PaddingTop(10).Text($"""
                                    Passenger: {passenger.Name} {passenger.Surname}
                                    Seat: {passenger.SeatNumber ?? "Not Assigned"}
                                    """);
                            }
                        });
                });
            }).GeneratePdf();
        }
    }
}