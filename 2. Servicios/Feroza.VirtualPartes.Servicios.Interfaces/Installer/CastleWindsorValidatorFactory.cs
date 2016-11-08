// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CastleWindsorValidatorFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the CastleWindsorValidatorFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Installer
{
    using System;

    using FluentValidation;

    /// <summary>The castle windsor validator factory.</summary>
    public class CastleWindsorValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>The create instance.</summary>
        /// <param name="validatorType">The validator type.</param>
        /// <returns>The <see cref="IValidator"/>.</returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            return Ragolo.Core.IoC.IocHelper.Instance.Resolve(validatorType) as IValidator;
        }
    }
}
