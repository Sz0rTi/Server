using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class RoleOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }

    public class Role_To_RoleOut : Profile
    {
        public Role_To_RoleOut()
        {
            CreateMap<Role, RoleOut>();
        }
    }
}
