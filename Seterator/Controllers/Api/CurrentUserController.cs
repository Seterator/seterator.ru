using Microsoft.AspNetCore.Mvc;
using Seterator.Models.Api;
using Seterator.Services;

namespace Seterator.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentUserController : ControllerBase
    {
        CurrentUserService user;
        public CurrentUserController(CurrentUserService user)
        {
            this.user = user;
        }

        [HttpGet]
        public UserInformation Get()
        {
            return user.BaseInformation();
        }
    }
}
