using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class TaxStageOut
    {
        public Guid ID { get; set; }
        public double Stage { get; set; }
    }

    public class TaxStage_To_TaxStageOut : Profile
    {
        public TaxStage_To_TaxStageOut()
        {
            CreateMap<TaxStage, TaxStageOut>();
        }
    }
}
