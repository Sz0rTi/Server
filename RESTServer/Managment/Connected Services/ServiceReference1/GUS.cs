using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Connected_Services.ServiceReference1
{
    public class GUS : IUslugaBIRzewnPubl
    {
        public Task<DanePobierzPelnyRaportResponse> DanePobierzPelnyRaportAsync(DanePobierzPelnyRaportRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DanePobierzRaportZbiorczyResponse> DanePobierzRaportZbiorczyAsync(DanePobierzRaportZbiorczyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DaneSzukajPodmiotyResponse> DaneSzukajPodmiotyAsync(DaneSzukajPodmiotyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetValueResponse> GetValueAsync(GetValueRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<WylogujResponse> WylogujAsync(WylogujRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ZalogujResponse> ZalogujAsync(ZalogujRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
