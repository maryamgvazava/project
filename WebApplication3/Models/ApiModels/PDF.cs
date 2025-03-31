using static WebApplication3.Models.ApiModels.TicketRequest;

namespace WebApplication3.Models.ApiModels
{
    public class PDF
    {
        public int Sulfasi { get; set; }
        public Train train { get; set; }
        public List<Pirovneba> People { get; set; } = new List<Pirovneba>();
        public string sakontaqtogmaili { get; set; }
        public string sakontaqtonomeri { get; set; }
        public string ticketid { get; set; }
    }
}
