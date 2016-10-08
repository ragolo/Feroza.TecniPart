using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feroza.TecniPart.Web.UI.CommunicationApi
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}