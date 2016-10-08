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

    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using Feroza.TecniPart.Web.UI.CommunicationApi.Providers;

    using Infraestructura.ResolucionDepencias;

    using Microsoft.Owin.Security.OAuth;

    using Owin;

    using Windsor;

    public class Startup
    {
        private static IWindsorContainer container;

        public void Configuration(IAppBuilder app)
        {
            this.ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}