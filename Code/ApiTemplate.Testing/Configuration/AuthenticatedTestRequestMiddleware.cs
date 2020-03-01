using Microsoft.AspNetCore.Http;
using ApiTemplate.Api.Utils;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiTemplate.Testing.Configuration
{
    public class AuthenticatedTestRequestMiddleware
    {
        private const string TestingAccessTokenAuthentication = "TestingAccessTokenAuthentication";
        private readonly RequestDelegate _next;

        public AuthenticatedTestRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains("X-Integration-Testing"))
            {
                var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Authentication, "IntegrationTestingToken"),
                    new Claim("scope", ApiTemplateApiScopes.ApiTemplateApi)
                }, TestingAccessTokenAuthentication);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                context.User = claimsPrincipal;
            }

            await _next(context);
        }
    }
}