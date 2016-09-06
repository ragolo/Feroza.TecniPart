// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   The startup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Feroza.TecniPart.Web.UI.Startup))]

namespace Feroza.TecniPart.Web.UI
{
    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
