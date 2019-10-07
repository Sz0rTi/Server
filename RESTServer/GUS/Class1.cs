using ServiceReference1;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WcfCoreMtomEncoder;

namespace GUS
{
    public class Class1
    {
        public async void info()
        {
            var encoding = new MtomMessageEncoderBindingElement(new TextMessageEncodingBindingElement());
            var transport = new HttpsTransportBindingElement();
            var customBinding = new CustomBinding(encoding, transport);

            /*var client = new UslugaBIRzewnPublClient(customBinding, new System.ServiceModel.EndpointAddress("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc"));
            ZalogujResponse x = await client.ZalogujAsync(new ZalogujRequest("af6e48d41670417a9b67"));
            
            return x.ZalogujResult;*/
            var client = new UslugaBIRzewnPublClient(customBinding, new System.ServiceModel.EndpointAddress("https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc"));
            ZalogujResponse x = await client.ZalogujAsync(new ZalogujRequest("af6e48d41670417a9b67"));

            DaneSzukajPodmiotyRequest req = new DaneSzukajPodmiotyRequest(new ParametryWyszukiwania { Nip = "8211022391" });

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
                + "<dat:Nip>8211022391</dat:Nip>"
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
            //request.Headers.Clear();
            request.Headers.Add("sid", x.ZalogujResult);
            using (var stream = request.GetRequestStream())
            {
                stream.Write(byteData, 0, byteData.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            XmlDocument odp = new XmlDocument();

            odp.LoadXml(z);

            WylogujRequest wylogujRequest = new WylogujRequest(x.ZalogujResult);
            WylogujResponse wylogujResponse = await client.WylogujAsync(wylogujRequest);
        }

    }
}
/*"<?xml version=\"1.0\" encoding=\"utf - 8\" ?>"+
                "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\"" + " xmlns:ns=\"http://CIS/BIR/PUBL/2014/07\" xmlns:dat=\"http://CIS/BIR/PUBL/2014/07/DataContract\">" +
                "\n<soap:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">" +
                "\n<wsa:To>https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc</wsa:To>" +
                "\n<wsa:Action>http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajPodmioty</wsa:Action>" +
                "\n</soap:Header>" +
                "\n<soap:Body>" +
                "\n<ns:DaneSzukajPodmioty>" +
                "\n<ns:pParametryWyszukiwania>" +
                "\n<dat:Nip>" + res.DaneSzukajPodmiotyResult + "</dat:Nip>" +
                "\n</ns:pParametryWyszukiwania>" +
                "\n</ns:DaneSzukajPodmioty>" +
                "\n</soap:Body>"+
                "\n</soap:Envelope>");*/

