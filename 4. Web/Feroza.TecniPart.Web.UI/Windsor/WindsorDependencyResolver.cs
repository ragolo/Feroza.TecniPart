// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindsorDependencyResolver.cs" company="">
//   
// </copyright>
// <summary>
//   The windsor dependency resolver.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Windsor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    using Castle.Windsor;

    /// <summary>
    /// The windsor dependency resolver.
    /// </summary>
    public class WindsorDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// The _container.
        /// </summary>
        private readonly IWindsorContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyScope"/>.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container);
        }

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetService(Type serviceType)
        {
            return this.container.Kernel.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            // This "not has component" part is from "Pro ASP.NET Web API" p. 426
            if (!this.container.Kernel.HasComponent(serviceType))
            {
                return new object[0];
            }

            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.container.Dispose();
        }
    }
}