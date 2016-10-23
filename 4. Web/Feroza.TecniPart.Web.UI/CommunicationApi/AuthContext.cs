// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthContext.cs" company="">
//   
// </copyright>
// <summary>
//   The auth context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.CommunicationApi
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>The auth context.</summary>
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>Initializes a new instance of the <see cref="AuthContext"/> class.</summary>
        public AuthContext() : base("AuthContext")
        {
        }
    }
}