using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class UnitOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }

    public class Unit_To_UnitOut : Profile
    {
        public Unit_To_UnitOut()
        {
            CreateMap<Unit, UnitOut>();
        }
    }
}
