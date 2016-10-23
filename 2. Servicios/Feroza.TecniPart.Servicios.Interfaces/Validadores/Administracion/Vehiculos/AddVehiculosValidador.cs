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
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;

    /// <summary>The add vehiculos validador.</summary>
    public class AddVehiculosValidador : AbstractValidator<Vehiculos>
    {
        /// <summary>The vehiculos repository.</summary>
        private readonly IRepository<Vehiculos> vehiculosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddVehiculosValidador"/> class. Initializes a new instance of the <see cref="VehiculosValidador"/> class.</summary>
        /// <param name="vehiculosRepository"></param>
        public AddVehiculosValidador(IRepository<Vehiculos> vehiculosRepository)
        {
            this.vehiculosRepository = vehiculosRepository;
            this.RuleFor(r => r.IdFabricantes).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdMarca).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdVehiculos).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Descripcion).NotNull().NotEmpty();

            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            this.RuleFor(r => r.Ango).NotEmpty().Must(this.ValidacionAño);
            this.RuleFor(r => r.IdVehiculos).Must(this.NoExisteOtroVehiculos).WithMessage($"Ya existe otro Pais con el mismo identificador");
            this.RuleFor(r => r.Descripcion).Must(this.NoExisteOtraDescripcionVehiculos).WithMessage($"Ya existe otra Marca con el mismo nombre");

        }

        /// <summary>The no existe otro vehiculos.</summary>
        /// <param name="idVehiculos">The id vehiculos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroVehiculos(int idVehiculos)
        {
            return this.vehiculosRepository.GetById(idVehiculos) == null;
        }

        /// <summary>The validacion año.</summary>
        /// <param name="ango">The ango.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool ValidacionAño(string ango)
        {
            return Convert.ToInt32(ango) >= DateTime.MinValue.Year;
        }

        /// <summary>The no existe otra descripcion vehiculos.</summary>
        /// <param name="descripcion">The descripcion.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraDescripcionVehiculos(string descripcion)
        {
            return !this.vehiculosRepository.GetFiltered(r => r.Descripcion.Equals(descripcion)).Any();
        }
    }
}