// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindsorDependencyScope.cs" company="">
//   
// </copyright>
// <summary>
//   The windsor dependency scope.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Windsor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    using Castle.MicroKernel.Lifestyle;
    using Castle.Windsor;

    /// <summary>
    /// The windsor dependency scope.
    /// </summary>
    internal class WindsorDependencyScope : IDependencyScope
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IWindsorContainer container;

        /// <summary>
        /// The scope.
        /// </summary>
        private readonly IDisposable scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorDependencyScope"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public WindsorDependencyScope(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
            this.scope = container.BeginScope();
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetService(Type type)
        {
            return this.container.Kernel.HasComponent(type)
            ? this.container.Resolve(type) : null;
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<object> GetServices(Type type)
        {
            return this.container.ResolveAll(type)
            .Cast<object>().ToArray();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.scope.Dispose();
        }
    }
}