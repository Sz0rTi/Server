using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Resources
{
    public class UserResource
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
    }
}
