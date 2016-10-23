// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Feroza.TecniPart.Web.UI;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Feroza.TecniPart.Web.UI
{
    using System;
    using System.Web.Http;

    using CommunicationApi.Providers;

    using Microsoft.Owin.Security.OAuth;

    using Owin;

    /// <summary>The startup.</summary>
    public class Startup
    {
        /// <summary>The configuration.</summary>
        /// <param name="app">The app.</param>
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureOAuth(app);
            var config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        /// <summary>The configure o auth.</summary>
        /// <param name="app">The app.</param>
        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}