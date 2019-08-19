using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class CategoryIn
    {
        public string Name { get; set; }
    }

    public class CategoryIn_To_Category : Profile
    {
        public CategoryIn_To_Category()
        {
            CreateMap<CategoryIn, Category>()
                .ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.Products, e => e.Ignore());
        }
    }
}
