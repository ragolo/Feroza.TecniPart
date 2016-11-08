// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleAuthorizationServerProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The simple authorization server provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.CommunicationApi.Providers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.Owin.Security.OAuth;

    /// <summary>The simple authorization server provider.</summary>
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>The validate client authentication.</summary>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>The grant resource owner credentials.</summary>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthRepository repository = new AuthRepository())
            {
                var user = await repository.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "El usuario o contraseña es incorrecto.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}