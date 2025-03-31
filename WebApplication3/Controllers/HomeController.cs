using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Razor.Templating.Core;
using WebApplication3.Models;
using WebApplication3.Models.ApiModels;
using WebApplication3.Models.ViewModels;
using WebApplication3.Services;
using static WebApplication3.Models.ApiModels.TicketRequest;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRailwayService _railwayService;
        private readonly ILogger<HomeController> _logger;
        private readonly IStationService _stationService;
        public HomeController(
            IRailwayService railwayService,
            ILogger<HomeController> logger,
            IStationService stationService)
        {
            _railwayService = railwayService;
            _logger = logger;
            _stationService = stationService;
        }

        public async Task<IActionResult> Index()
        {
            var task = await _stationService.GetStationsAsync();
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string saidan,string sad,string date,string quantity)
        {
                var departures = await _railwayService.GetDeparturesAsync(
                    saidan,sad,date
                );
            HttpContext.Session.SetString("date", date);

            HttpContext.Session.SetString("raodenoba", quantity);
            return View(departures);
        }
        public async Task<IActionResult> Dajavshna(int trainid)
        {
            var train = await _railwayService.GetTrainDetailsAsync(trainid);
            var adgilebi = await _railwayService.GetVagon(3);
            ViewBag.adgilebi = adgilebi;
            return View(train);
        }
        public async Task<IActionResult> Saboloo(string departureid, string sakontaqtogmail, string sakontaqtonomeri,
            List<string> saxeli, List<string> gvari, List<string> piradinomeri, List<string> adgili)
        {

            var adgilebi = await _railwayService.GetVagon(3);
            var train = await _railwayService.GetTrainDetailsAsync(int.Parse(departureid));
            TicketRequest ticketRequest = new();
            ticketRequest.TrainId = int.Parse(departureid);
            ticketRequest.PhoneNumber = sakontaqtonomeri;
            ticketRequest.Email = sakontaqtogmail;
            ticketRequest.Date = DateTime.Parse(HttpContext.Session.GetString("date"));
            ticketRequest.People = saxeli
    .Select((name, index) => new PassengerRequest
    {
        SeatId = adgilebi
            .SelectMany(vagon => vagon.Seats)
            .FirstOrDefault(seat => seat.Number == adgili.ElementAtOrDefault(index))?.SeatId ?? Guid.Empty,
        Name = saxeli.ElementAtOrDefault(index) ?? "",
        Surname = gvari.ElementAtOrDefault(index) ?? "",
        IdNumber = piradinomeri.ElementAtOrDefault(index) ?? "",
        Status = "string",
        PayoutCompleted = true
    })
    .Where(p => p.SeatId != Guid.Empty)
    .ToList();
            PDF pdf = new PDF();
            var createticket = await _railwayService.CreateTicketAsync(ticketRequest);
            string tick_id = "";
            bool oriwertili = false;
            foreach (var i in createticket)
            {
                if (oriwertili)
                {
                    tick_id += i;
                }
                if (i == ':') {
                    oriwertili = true;
                }
            }
            pdf.ticketid = tick_id;
            pdf.sakontaqtonomeri = sakontaqtonomeri;
            pdf.sakontaqtogmaili = sakontaqtogmail;
            List<Pirovneba> pirovneba = new List<Pirovneba>();
            for(int i = 0; i < saxeli.Count; ++i)
            {
                Pirovneba pirovneba1 = new();
                pirovneba1.saxeli = saxeli[i];
                pirovneba1.gvari = gvari[i];
                pirovneba1.adgili = adgili[i];
                pirovneba1.piradinomeri = piradinomeri[i];
                pirovneba.Add(pirovneba1);
            }
            pdf.People = pirovneba;
            int sul_fasi = 0;
            foreach(var i in adgili)
            {
                foreach(var j in adgilebi)
                {
                    var fasi = j.Seats.FirstOrDefault(x => x.Number == i).Price;
                    sul_fasi +=Decimal.ToInt32(fasi);
                }
            }
            pdf.Sulfasi = sul_fasi;
            pdf.train = train;
            HttpContext.Session.SetString("PDF", JsonConvert.SerializeObject(pdf));
            return View(pdf);
        }
        public async Task<IActionResult> GetPdf()
        {
            var pdfJson = HttpContext.Session.GetString("PDF");
            PDF pdf = new(); ;
            if (pdfJson != null)
            {
                 pdf = JsonConvert.DeserializeObject<PDF>(pdfJson);
            }
            var pdfservice = new PdfService();
            string date = HttpContext.Session.GetString("date");
            var document = pdfservice.GetPdf(pdf, date);
            MemoryStream stream = new();
            document.Save(stream);
            Response.ContentType = "application/pdf";
            Response.Headers.Add("content-length", stream.Length.ToString());
            byte[] bytes = stream.ToArray();
            stream.Close();
            return File(bytes,"application/pdf","invoice.pdf");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = HttpContext.TraceIdentifier
            });
        }
    }
}