using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class ProductOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double PriceNetto { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public Guid TaxStageID { get; set; }
        public Guid UnitID { get; set; }
        public int Amount { get; set; }
    }

    public class Product_To_ProductOut : Profile
    {
        public Product_To_ProductOut()
        {
            CreateMap<Product, ProductOut>();
                /*.ForMember(e => e.Unit, e => e.MapFrom(m => m.Unit))
                .ForMember(e => e.Category, e => e.MapFrom(m => m.Category))
                .ForMember(e => e.TaxStage, e => e.MapFrom(m => m.Category));
            CreateMap<Unit, UnitOut>();
            CreateMap<Category, CategoryOut>();
            CreateMap<TaxStage, TaxStageOut>();*/
                
        }
    }
}
