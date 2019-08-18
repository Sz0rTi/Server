using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class UserOut
    {
        public Guid ID { get; set; }
        public string Login { get; set; }
        public Guid RoleID { get; set; }
    }

    public class User_To_UserOut : Profile
    {
        public User_To_UserOut()
        {
            CreateMap<User, UserOut>();
        }
    }
}
