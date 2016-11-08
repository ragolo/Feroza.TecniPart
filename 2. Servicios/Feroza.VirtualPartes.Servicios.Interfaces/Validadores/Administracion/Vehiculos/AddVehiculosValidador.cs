// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddVehiculosValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddVehiculosValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Vehiculos
{
    using System;
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add vehiculos validador.</summary>
    public class AddVehiculosValidador : AbstractValidator<Vehiculos>
    {
        /// <summary>The vehiculos repository.</summary>
        private readonly IRepositorio<Vehiculos> vehiculosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddVehiculosValidador"/> class. Initializes a new instance of the <see cref="VehiculosValidador"/> class.</summary>
        /// <param name="vehiculosRepository"></param>
        public AddVehiculosValidador(IRepositorio<Vehiculos> vehiculosRepository)
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
            return this.vehiculosRepository.ObtenerPorId(idVehiculos) == null;
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
            return !this.vehiculosRepository.Obtener(r => r.Descripcion.Equals(descripcion)).Any();
        }
    }
}