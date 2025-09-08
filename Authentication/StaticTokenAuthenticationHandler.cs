using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace StudentAPI.Authentication
{
    public class StaticTokenAuthenticationHandler : AuthenticationHandler<StaticTokenAuthenticationSchemeOptions>
    {
        public StaticTokenAuthenticationHandler(
            IOptionsMonitor<StaticTokenAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder)
            : base(options, logger, encoder)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header not found."));
            }

            var token = authorizationHeader.ToString();
            if (token != StaticTokenAuthenticationSchemeOptions.StaticToken)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid token."));
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "StaticUser")
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
