using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WebApplication3.Models.ApiModels;


namespace WebApplication3.Services
{
    public class PDFService
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
                    page.Margin(2, Unit.Centimetre);

                    page.Header()
                        .AlignCenter()
                        .Text("Train Ticket")
                        .FontSize(20).Bold();

                    page.Content()
                        .PaddingVertical(10)
                        .Column(col =>
                        {
                            col.Item().Text($"Ticket ID: {ticket.Id}");
                            col.Item().Text($"Status: {ticket.Status}");
                            col.Item().Text($"Train: {ticket.TrainNumber}");

                            foreach (var passenger in ticket.Passengers)
                            {
                                col.Item().PaddingTop(10).Text($"""
                                    Passenger: {passenger.FirstName} {passenger.LastName}
                                    Seat: {passenger.SeatNumber}
                                    """);
                            }
                        });
                });
            }).GeneratePdf();
        }
    }
}