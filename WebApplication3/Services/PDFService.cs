using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel;
using WebApplication3.Models.ApiModels;
namespace WebApplication3.Services
{
    public class PdfService()
    {
        public PdfDocument GetPdf(PDF pdf,string date)
        {
            var document = new Document();
            BuildDocument(document,pdf,date);
            var pdfrenderer = new PdfDocumentRenderer();
            pdfrenderer.Document = document;
            pdfrenderer.RenderDocument();
            return pdfrenderer.PdfDocument;
        }
        public void BuildDocument(Document document,PDF pdf,string date)
        {
            Section section = document.AddSection();
            var paragrap = section.AddParagraph();
            paragrap.Format.Font.Name = "Arial";
            paragrap.AddText($"Baratis Nomeri:{pdf.ticketid}");
            paragrap.AddLineBreak();
            paragrap.AddText($"Gacemis Tarigi:{DateTime.Now.Year}-0{DateTime.Now.Month}-{DateTime.Now.Day}");
            paragrap.AddLineBreak();
            Dictionary<string, string> dict = new();
            dict["თბილისი"] = "Tbilisi";
            dict["ბათუმი"] = "Batumi";
            dict["ფოთი"] = "Poti";
             paragrap.AddText($"Gamgzavreba {dict[pdf.train.From]} {pdf.train.DepartureTime}       Chasvla:{dict[pdf.train.To]} {pdf.train.ArrivalTime}   Gasvlis Tarigi:{date}");
            paragrap.AddLineBreak();
            paragrap.AddText($"Sakontaqto Informacia");
            paragrap.AddLineBreak();
            paragrap.AddText($"Emaili {pdf.sakontaqtogmaili}                    Telefonis Nomeri {pdf.sakontaqtonomeri}");
            paragrap.AddLineBreak();
            paragrap.AddText("Mgzavrebi");
            paragrap.AddLineBreak();
            var table = section.AddTable();
            table.AddColumn("3cm"); 
            table.AddColumn("5cm"); 

            foreach (var i in pdf.People)
            {
                var row = table.AddRow();
                row.Cells[0].AddParagraph("Saxeli: ");
                row.Cells[1].AddParagraph(i.saxeli);
                row.Cells[0].AddParagraph("Gvari: ");
                row.Cells[1].AddParagraph(i.gvari);
                row.Cells[0].AddParagraph("Adgili: ");
                row.Cells[1].AddParagraph(i.adgili);
                row.Cells[0].AddParagraph("Vagoni: ");
                row.Cells[1].AddParagraph("3");
                var spaceRow = table.AddRow();  
                spaceRow.Cells[0].AddParagraph(""); 
                spaceRow.Cells[1].AddParagraph("");  
            }
            paragrap.AddText($"Sul Gadaxdilia ${pdf.Sulfasi}");
            
        }
    }
}
