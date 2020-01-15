
using HtmlAgilityPack;

using OpenQA.Selenium.Chrome;
using System.IO;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace PDF
{
    public class PDFService : IPDFService
    {
        public bool CreateHTML()
        {
            HtmlDocument html = new HtmlDocument();
            html.Load("html.html");
            string a = html.Text;

            //IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            //Renderer.RenderHtmlAsPdf(a).SaveAs("testOWY.pdf");

            return true;
        }


        
    }
    public interface IPDFService
    {
        bool CreateHTML();
    }
}
