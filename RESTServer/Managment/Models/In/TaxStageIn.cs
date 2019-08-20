using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class TaxStageIn
    {
        public double Stage { get; set; }
    }

    public class TaxStageIn_To_TaxStage : Profile
    {
        public TaxStageIn_To_TaxStage()
        {
            CreateMap<TaxStageIn, TaxStage>()
                .ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.Product, e => e.Ignore());
        }
    }
}
