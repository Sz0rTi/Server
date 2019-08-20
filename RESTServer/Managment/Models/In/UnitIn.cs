using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class UnitIn
    {
        public string Name { get; set; }
    }

    public class UnitIn_To_Unit : Profile
    {
        public UnitIn_To_Unit()
        {
            CreateMap<UnitIn, Unit>()
                .ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.Products, e => e.Ignore());
        }
    }
}
