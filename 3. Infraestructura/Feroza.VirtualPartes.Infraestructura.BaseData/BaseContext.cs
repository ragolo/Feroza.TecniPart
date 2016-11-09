// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseContext.cs" company="">
//   
// </copyright>
// <summary>
//   The base context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.BaseData
{
    using System.Data.Entity;

    /// <summary>The base context.</summary>
    /// <typeparam name="TContext"></typeparam>
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        /// <summary>Initializes static members of the <see cref="BaseContext"/> class.</summary>
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }

        /// <summary>Initializes a new instance of the <see cref="BaseContext{TContext}"/> class.</summary>
        protected BaseContext() : base("name=ModelVirtualPartes")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
