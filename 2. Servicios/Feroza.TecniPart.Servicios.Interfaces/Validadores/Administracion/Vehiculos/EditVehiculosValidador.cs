// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddVehiculosValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddVehiculosValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Vehiculos
{
    using System;

    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add fabricantes validador.</summary>
    public class EditVehiculosValidador : AbstractValidator<Vehiculos>
    {
        /// <summary>The fabricantes repository.</summary>
        private readonly IRepository<Vehiculos> catalogosRepository;

        /// <summary>Initializes a new instance of the <see cref="EditVehiculosValidador"/> class. Initializes a new instance of the <see cref="VehiculosValidador"/> class.</summary>
        /// <param name="fabricantesRepository">The fabricantes Repository.</param>
        public EditVehiculosValidador(IRepository<Vehiculos> catalogosRepository)
        {
            this.catalogosRepository = catalogosRepository;
            this.RuleFor(r => r.IdFabricantes).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdMarca).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdVehiculos).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Descripcion).NotNull().NotEmpty();

            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            this.RuleFor(r => r.Ango).NotEmpty().Must(this.ValidacionAño);
            this.Custom(r => this.NoExisteOtroVehiculos(r));
        }

        /// <summary>The no existe otro fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroVehiculos(Vehiculos fabricantes)
        {
            //if (this.fabricantesRepository.GetFiltered(r => r.IdVehiculos == fabricantes.IdVehiculos && r.Descripcion.Equals(fabricantes.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Vehiculos con el mismo identificador");
            //}

            return null;
        }

        /// <summary>The validacion año.</summary>
        /// <param name="ango">The ango.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ValidacionAño(string ango)
        {
            return Convert.ToInt32(ango) >= DateTime.MinValue.Year;
        }
    }
}