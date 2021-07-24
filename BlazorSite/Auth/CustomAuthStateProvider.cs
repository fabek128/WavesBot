using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorSite.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "mrfibuli"),
            }, "Fake authentication type");

            identity.AddClaim(new Claim(ClaimTypes.Surname, "Mi surname"));
            identity.AddClaim(new Claim(ClaimTypes.Email, "fabianfigueredo@gmail.com"));

            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }

        public void Login(string ){

        }

    }
}