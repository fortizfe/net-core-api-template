using Microsoft.AspNetCore.Authorization;

namespace ApiTemplate.Core.Utils.Extensions.Authorization
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(params string[] roles)
        {
            if (roles?.Length > 0)
                base.Roles = string.Join(',', roles);
        }
    }
}