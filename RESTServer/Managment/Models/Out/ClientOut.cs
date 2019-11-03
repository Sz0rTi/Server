using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class ClientOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string NIP { get; set; }
    }

    public class Client_To_ClientOut : Profile
    {
        public Client_To_ClientOut()
        {
            CreateMap<Client, ClientOut>();
        }
    }
}
