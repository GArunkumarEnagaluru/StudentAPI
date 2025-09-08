using Microsoft.AspNetCore.Authentication;

namespace StudentAPI.Authentication
{
    public class StaticTokenAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public const string StaticToken = "my-secret-token";
    }
}
