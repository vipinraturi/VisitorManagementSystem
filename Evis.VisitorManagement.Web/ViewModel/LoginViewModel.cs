﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evis.VisitorManagement.Web.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel() { }
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isPasswordSave { get; set; }
    }
}