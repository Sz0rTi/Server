using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class CategoryOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }

    public class Category_To_CategoryOut : Profile
    {
        public Category_To_CategoryOut()
        {
            CreateMap<Category, CategoryOut>();
        }
    }
}
