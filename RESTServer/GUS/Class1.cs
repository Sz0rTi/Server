using ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WcfCoreMtomEncoder;

namespace GUS
{
    public class Class1
    {
        public Company company { get; set; }

        public Class1(string nip)
        {
            this.company = info2(info(nip).Result);
        }
        public async Task<string> info(string nip)
        {
            var encoding = new MtomMessageEncoderBindingElement(new TextMessageEncodingBindingElement());
            var transport = new HttpsTransportBindingElement();
            var customBinding = new CustomBinding(encoding, transport);

            /*var client = new UslugaBIRzewnPublClient(customBinding, new System.ServiceModel.EndpointAddress("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc"));
            ZalogujResponse x = await client.ZalogujAsync(new ZalogujRequest("af6e48d41670417a9b67"));
            
            return x.ZalogujResult;*/
            var client = new UslugaBIRzewnPublClient(customBinding, new System.ServiceModel.EndpointAddress("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc"));
            ZalogujResponse x = await client.ZalogujAsync(new ZalogujRequest("af6e48d41670417a9b67"));

            DaneSzukajPodmiotyRequest req = new DaneSzukajPodmiotyRequest(new ParametryWyszukiwania { Nip = nip });

            DaneSzukajPodmiotyResponse res = await client.DaneSzukajPodmiotyAsync(req);

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(
                "<soap:Envelope xmlns:soap = \"http://www.w3.org/2003/05/soap-envelope\" xmlns:ns = \"http://CIS/BIR/PUBL/2014/07\" xmlns:dat = \"http://CIS/BIR/PUBL/2014/07/DataContract\">"
                + "<soap:Header xmlns:wsa = \"http://www.w3.org/2005/08/addressing\">"
                + "<wsa:To>https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc</wsa:To>"
                + "<wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajPodmioty</wsa:Action>"
                + "</soap:Header>"
                + "<soap:Body>"
                + "<ns:DaneSzukajPodmioty>"
                + "<ns:pParametryWyszukiwania>"
                + "<dat:Nip>"+nip+"</dat:Nip>"
                + "</ns:pParametryWyszukiwania>"
                + "</ns:DaneSzukajPodmioty>"
                + "</soap:Body>"
                + "</soap:Envelope>");
            XmlSerializer serializer = new XmlSerializer(typeof(XmlWriter));

            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            xml.WriteTo(tx);
            string str = sw.ToString();
            var byteData = Encoding.UTF8.GetBytes(str);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc");
            request.Method = "POST";
            request.ContentType = "application/soap+xml";
            request.Accept = "application/xop+xml";
            request.Headers.Add("sid", x.ZalogujResult);
            using (var stream = request.GetRequestStream())
            {
                stream.Write(byteData, 0, byteData.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Headers.Clear();
            
            string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            WylogujRequest wylogujRequest = new WylogujRequest(x.ZalogujResult);
            WylogujResponse wylogujResponse = await client.WylogujAsync(wylogujRequest);
            return responseString;
        }

        public Company info2(string a)
        {
            a = a.Substring(0, 12 + a.LastIndexOf("/s:Envelope>"));
            a = a.Replace("&lt;", "<");
            a = a.Replace("&gt", ">");
            a = a.Replace(";&#xD;", "");
            a = a.Replace(";", "");
            a = a.Replace("\n", "");
            a = a.Replace("&amp", "");
            a = a.Substring(a.IndexOf("<dane", StringComparison.Ordinal));
            a = a.Substring(0, 6 + a.LastIndexOf("/dane>"));
            XmlDocument odp = new XmlDocument();
            odp.LoadXml(a);
            if(odp.GetElementsByTagName("ErrorCode").Count == 0)
            {
                Company company = new Company();
                company.Name = odp.GetElementsByTagName("Nazwa")[0].InnerText;
                company.City = odp.GetElementsByTagName("Miejscowosc")[0].InnerText;
                company.PostCode = odp.GetElementsByTagName("KodPocztowy")[0].InnerText;
                company.Street = odp.GetElementsByTagName("Ulica")[0].InnerText;
                company.Number = odp.GetElementsByTagName("NrNieruchomosci")[0].InnerText;
                company.NIP = odp.GetElementsByTagName("Nip")[0].InnerText;
                if (odp.GetElementsByTagName("NrLokalu")[0].Name != "") company.Number += "/" + odp.GetElementsByTagName("NrLokalu")[0].InnerText;
                return company;
            }
            else
            {
                return new Company();
            }
        }

    }
}


