using Seterator.Models.Api;

namespace Seterator.Services
{
    public class CurrentUserService
    {
        private readonly AuthService auth;
        public CurrentUserService(AuthService auth)
        {
            this.auth = auth;
        }
        public UserInformation BaseInformation()
        {
            if (auth.IsCurrentUserAuthorized())
            {
                return new UserInformation()
                {
                    IsAuthorized = true,
                    Username = auth.CurrentUserLogin(),
                    Roles = auth.CurrentUserRoles()
                };
            }
            else
            {
                return new UserInformation()
                {
                    IsAuthorized = false,
                    Username = null,
                    Roles = null
                };
            }
        }
    }
}
