using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seterator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        DatabaseContext database;
        public ProfileController(DatabaseContext database)
        {
            this.database = database;
        }
        
        [HttpPut]
        public IActionResult UpdateProfile(UserProfile profile)
        {
            database.Profiles.Update(profile);
            database.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProfiles([FromBody] Models.Api.ProfileRequest request)
        {
            try
            {
                if (request.Type == Models.Api.ProfileRequest.ProfileRequestType.list)
                {
                    return Profiles(request.Guid.Value);
                }
                else if (request.Type == Models.Api.ProfileRequest.ProfileRequestType.concrete)
                {
                    return Profile(request.Guid.Value);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        protected IActionResult Profile(Guid roleGuid)
        {
            try
            {
                var profile = database.Profiles.Single(x => x.RoleGuid == roleGuid);
                return Ok(profile);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
        protected IActionResult Profiles(Guid userGuid)
        {
            return Ok(database.Roles.Where(x => x.UserGuid == userGuid)
                .Join(database.Profiles,
                      role => role.Guid,
                      profile => profile.RoleGuid,
                      (role, profile) => profile));
        }
    }
}
