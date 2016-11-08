// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindsorCompositionRoot.cs" company="">
//   
// </copyright>
// <summary>
//   The windsor composition root.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Web.UI.Windsor
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    /// <summary>
    /// The windsor composition root.
    /// </summary>
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IWindsorContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorCompositionRoot"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public WindsorCompositionRoot(IWindsorContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="controllerDescriptor">
        /// The controller descriptor.
        /// </param>
        /// <param name="controllerType">
        /// The controller type.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpController"/>.
        /// </returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller =
                (IHttpController)this.container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(
                    () => this.container.Release(controller)));

            return controller;
        }

        /// <summary>
        /// The release.
        /// </summary>
        private class Release : IDisposable
        {
            /// <summary>
            /// The release.
            /// </summary>
            private readonly Action release;

            /// <summary>
            /// Initializes a new instance of the <see cref="Release"/> class.
            /// </summary>
            /// <param name="release">
            /// The release.
            /// </param>
            public Release(Action release)
            {
                this.release = release;
            }

            /// <summary>
            /// The dispose.
            /// </summary>
            public void Dispose()
            {
                this.release();
            }
        }
    }
}