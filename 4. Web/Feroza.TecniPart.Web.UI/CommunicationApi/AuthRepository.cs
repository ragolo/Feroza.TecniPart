// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthRepository.cs" company="">
// </copyright>
// <summary>
//   Defines the AuthRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Feroza.TecniPart.Web.UI.CommunicationApi
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    /// <summary>The auth repository.</summary>
    public class AuthRepository : IDisposable
    {
        /// <summary>The context.</summary>
        private AuthContext context;

        /// <summary>The user manager.</summary>
        private UserManager<IdentityUser> userManager;

        /// <summary>Initializes a new instance of the <see cref="AuthRepository"/> class.</summary>
        public AuthRepository()
        {
            this.context = new AuthContext();
            this.userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(this.context));
        }

        /// <summary>The register user.</summary>
        /// <param name="userModel">The user model.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IdentityResult> RegisterUser(UsuarioModelo userModel)
        {
            var user = new IdentityUser
            {
                UserName = userModel.NombreUsuario
            };

            var result = await this.userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        /// <summary>The find user.</summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await this.userManager.FindAsync(userName, password);

            return user;
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.context.Dispose();
            this.userManager.Dispose();
        }
    }
}