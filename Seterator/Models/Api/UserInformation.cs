using System.Collections.Generic;

#pragma warning disable CS8618

namespace Seterator.Models.Api
{
    public class UserInformation
    {
        public bool IsAuthorized { get; set; }
        public string? Username { get; set; }
        public List<string>? Roles { get; set; }
    }
}
