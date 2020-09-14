using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable CS8618

namespace Seterator.Models.Api
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Register
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AccountActionResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
