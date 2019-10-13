using GUS;
using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;


namespace Managment.Services
{
    public class GUSService : IGUSService
    {
        public Company GetInfo(string nip)
        {
            nip = nip.Replace("-", "");
            Class1 gus = new Class1(nip);
            return gus.company;
        }    
    }

    public interface IGUSService
    {
        Company GetInfo(string nip);
    }
}
