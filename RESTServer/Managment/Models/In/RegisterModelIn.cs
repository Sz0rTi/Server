﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string NIP { get; set; }
    }
}
