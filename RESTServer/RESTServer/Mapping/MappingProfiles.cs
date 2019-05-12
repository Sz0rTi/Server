using AutoMapper;
using RESTServer.Models;
using RESTServer.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryResource>().ReverseMap();
            CreateMap<Client, ClientResource>().ReverseMap();
            CreateMap<InvoiceBuy, InvoiceBuyResource>().ReverseMap();
            CreateMap<InvoiceSell, InvoiceSellResource>().ReverseMap();
            CreateMap<Product, ProductResource>().ReverseMap();
            CreateMap<ProductBuy, ProductBuyResource>().ReverseMap();
            CreateMap<ProductSell, ProductSellResource>().ReverseMap();
            CreateMap<Role, RoleResource>().ReverseMap();
            CreateMap<Seller, SellerResource>().ReverseMap();
            CreateMap<TaxStage, TaxStageResource>().ReverseMap();
            CreateMap<Unit, UnitResource>().ReverseMap();
            CreateMap<User, UserResource>().ReverseMap();
        }
    }
}
