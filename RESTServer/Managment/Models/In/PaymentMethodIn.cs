using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class PaymentMethodIn
    {
        public string Name { get; set; }
    }

    public class PaymentMethodIn_To_PaymentMethod : Profile
    {
        public PaymentMethodIn_To_PaymentMethod()
        {
            CreateMap<PaymentMethodIn, PaymentMethod>();
        }
    }
}
