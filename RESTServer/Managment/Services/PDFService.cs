using AutoMapper;
using DAO.Context;
using DAO.Models;
using DocXToPdfConverter;
using HtmlAgilityPack;
using IronPdf;
//using IronPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Managment.Services
{
    public class PDFService : IPDFService
    {
        private IMapper _mapper;
        private MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public PDFService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }
        public async Task<bool> CreateHTML(Guid id)
        {
            InvoiceSell invoice = _context.InvoicesSell.Where(i => i.UserID == UserId).Where(i => i.ID == id)
                .Include(i=>i.ProductsSell).First();
            ApplicationUser user = _context.Users.Where(u => u.Id == invoice.UserID).First();
            Client client = _context.Clients.Where(c => c.ID == invoice.ClientID).First();
            PaymentMethod pmethod = _context.PaymentMethods.Where(p => p.ID == invoice.PaymentMethodID).First();

            var test = new ReportGenerator(@"E:\Projekty\GitHub\SERWER\RESTServer\RESTServer");

            HtmlDocument html = new HtmlDocument();
            html.Load("1client.html");
            string a = html.Text;
            a += $"<title>Faktura VAT {invoice.Code}</title></head><body><header class=\"clearfix\"><h1>Faktura VAT {invoice.Code}</h1>" +
                "<div id=\"company\" class=\"clearfix\">" +
                "<div>Sprzedawca:</div></br>" +
                $"<div>{user.Name}</div>" +
                $"<div>{user.Address},<br>{user.PostCode}</div>" +
                $"<div>NIP: {user.NIP}</div></div>" +
                $"<div id=\"client\"><div>Nabywca:</div><br>" +
                $"<div>{client.Name}</div><div>{client.Street} {client.Number}</div>" +
                $"<div>{client.PostCode}, {client.City}</div>" +
                $"<div>NIP: {client.NIP}</div><br>" +
                $"<div>Data wystawienia: {invoice.Date}</div>" +
                $"<div>Termin płatności: {invoice.PaymentDeadline}</div>" +
                $"<div>Sposób płatności: {pmethod.Name}</div>" +
                $"</div></header><main>" +
                $"<table align=\"center\">" +
                $"<thead><tr>" +
                $"<th>L.p.</th><th class=\"desc\">Nazwa produktu</th>" +
                $"<th>Cena netto</th>" +
                $"<th>Stawka VAT</th>" +
                $"<th>Ilość</th>" +
                $"<th>J.M.</th>" +
                $"<th>Wartość netto</th>" +
                $"<th>Wartość brutto</th>" +
                $"</tr></thead><tbody>";
                for(int i=1;i<= invoice.ProductsSell.Count;i++)
                {
                    a += $"<tr><td>{i}.</td><td>{invoice.ProductsSell[i-1].Name}</td><td>{invoice.ProductsSell[i - 1].PricePerItemNetto}" +
                    $"</td><td>{GetTaxStage(invoice.ProductsSell[i-1].TaxStageID)}%</td><td>{invoice.ProductsSell[i-1].Amount}</td>" +
                    $"<td>{GetUnit(invoice.ProductsSell[i-1].UnitID)}</td>" +
                    $"<td>{(invoice.ProductsSell[i-1].Amount*invoice.ProductsSell[i-1].PricePerItemNetto).ToString("N2")}zł</td>" +
                    $"<td>{(invoice.ProductsSell[i-1].Amount * invoice.ProductsSell[i-1].PricePerItemBrutto).ToString("N2")}zł</td>" +
                    $"</tr>";
                }
                a += $"<tr><td colspan=\"7\">Suma netto</td>" +
                $"<td class=\"total\">{ invoice.PriceNetto.ToString("N2")}zł</td></tr>"+
                $"<tr><td colspan=\"7\">Suma brutto</td><td>{invoice.PriceBrutto.ToString("N2")}zł</td></tr>" +
                $"</tbody></table></br></br></br>" +
                $"<div style=\"overflow: hidden;\">" +
                $"<p style=\"float: left; padding-left: 300px;\"wystawił:</p>" +
                $"<p style=\"float: right; padding-right: 300px;\"odebrał:</p>" +
                $"</div>" +
                $"<div style=\"overflow: hidden;\">" +
                $"<p style=\"float: left; padding-left: 150px;\"podpis osoby upoważnionej:</p>" +
                $"<p style=\"float: right; padding-right: 150px;\"podpis osoby upoważnionej:</p>" +
                $"</div></main></body></html>"
                ;
            HtmlToPdf Renderer = new HtmlToPdf();
            Renderer.RenderHtmlAsPdf(a).SaveAs("testOWY.pdf");

            //PdfDocument pdfDocument = new PdfDocument();
            //PdfDocument pdf = PdfGenerator.GeneratePdf(a, PageSize.A4, 60);
            //pdf.Save("testoweggggg.pdf");
            //test.Convert(a, "testowy.pdf");
            return true;
        }

        public string GetTaxStage(Guid id)
        {
            return _context.TaxStages.Where(t => t.ID == id).First().Stage.ToString();
        }

        public string GetUnit(Guid id)
        {
            return _context.Units.Where(t => t.ID == id).First().Name;
        }

    }
    public interface IPDFService
    {
        Task<bool> CreateHTML(Guid id);
    }
}
