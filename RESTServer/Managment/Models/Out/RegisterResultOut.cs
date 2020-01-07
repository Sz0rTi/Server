using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.Out
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
