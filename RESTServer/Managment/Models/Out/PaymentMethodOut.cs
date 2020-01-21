using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.Out
{
    public class PaymentMethodOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }

    public class PaymentMethod_To_PaymentMethodOut : Profile
    {
        public PaymentMethod_To_PaymentMethodOut()
        {
            CreateMap<PaymentMethod,PaymentMethodOut>();
        }
    }
}
