using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class ClientIn
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string NIP { get; set; }
        //List<InvoiceSell> Invoices = new List<InvoiceSell>();
    }

    public class ClientIn_To_Client : Profile
    {
        public ClientIn_To_Client()
        {
            CreateMap<ClientIn, Client>()
                .ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.InvoicesSell, e => e.Ignore());
        }
    }
}
