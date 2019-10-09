using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class ProductIn
    {
        public string Name { get; set; }
        public double PriceNetto { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public Guid TaxStageID { get; set; }
        public Guid UnitID { get; set; }
        public int Amount { get; set; }
    }

    public class ProductIn_To_Product : Profile
    {
        public ProductIn_To_Product()
        {
            CreateMap<ProductIn, Product>();
                /*.ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.TaxStage, e => e.Ignore())
                .ForMember(e => e.Category, e => e.Ignore())
                .ForMember(e => e.Unit, e => e.Ignore());*/
        }
    }
}
