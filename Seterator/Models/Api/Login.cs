using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable CS8618

namespace Seterator.Models.Api
{
    public class Login
    {
        public string Method { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
