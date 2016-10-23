// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindsorValidatorFactory.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   The windsor validator factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Web.UI.Windsor.Installers
{
    using System;

    using Castle.Windsor;

    using FluentValidation;

    /// <summary>The windsor validator factory.</summary>
    public class WindsorValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>The _container.</summary>
        private readonly IWindsorContainer container;

        /// <summary>Initializes a new instance of the <see cref="WindsorValidatorFactory"/> class.</summary>
        /// <param name="container">The container.</param>
        public WindsorValidatorFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        /// <summary>The create instance.</summary>
        /// <param name="validatorType">The validator type.</param>
        /// <returns>The <see cref="IValidator"/>.</returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            if (this.container.Kernel.HasComponent(validatorType))
            {
                return this.container.Resolve(validatorType) as IValidator;
            }
            return null;
        }
    }
}