using GusInfo;
using Managment.Connected_Services.ServiceReference1;
using NIP24;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;


namespace Managment.Services
{
    public class GUSService
    {
        public async void GetInfo(string nip)
        {
            /*GUS gus = new GUS();
            ZalogujResponse x = await gus.ZalogujAsync(new ZalogujRequest("af6e48d41670417a9b67"));
            Console.WriteLine(x.ZalogujResult);*/

            UslugaBIRzewnPublClient klient = new UslugaBIRzewnPublClient();
            //ZalogujResponse x = await klient.ZalogujAsync("af6e48d41670417a9b67");
            //Console.WriteLine(klient.info());
        }    
        
        public void info()
        {
            NIP24Client nip = new NIP24Client();
            nip.URL = "https://www.nip24.pl/api-test/";
            Console.WriteLine(nip.GetInvoiceData("7272445205").Name);
            //
        }
        
    }
}
