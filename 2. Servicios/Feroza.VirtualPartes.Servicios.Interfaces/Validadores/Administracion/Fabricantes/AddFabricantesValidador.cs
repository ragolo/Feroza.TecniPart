// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddFabricantesValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddFabricantesValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Fabricantes
{
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add fabricantes validador.</summary>
    public class AddFabricantesValidador : AbstractValidator<Fabricantes>
    {
        private readonly IRepositorio<Fabricantes> fabricantesRepository;

        /// <summary>Initializes a new instance of the <see cref="AddFabricantesValidador"/> class. Initializes a new instance of the <see cref="FabricantesValidador"/> class.</summary>
        /// <param name="fabricantesRepository"></param>
        public AddFabricantesValidador(IRepositorio<Fabricantes> fabricantesRepository)
        {
            this.fabricantesRepository = fabricantesRepository;
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.IdPaises).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Nombre).Must(this.NoExisteOtroFabricante).WithMessage($"Ya existe otro fabricante con el mismo nombre");

            this.RuleFor(r => r.IdFabricantes).Must(this.NoExisteOtroFabricantes).WithMessage($"Ya existe otro Fabricantes con el mismo identificador");
        }

        /// <summary>The no existe otro fabricante.</summary>
        /// <param name="nombre">The nombre.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroFabricante(string nombre)
        {
            return !this.fabricantesRepository.Obtener(fabricante => fabricante.Nombre.Equals(nombre)).Any();
        }

        /// <summary>The no existe otro fabricantes.</summary>
        /// <param name="idFabricantes">The id fabricantes.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroFabricantes(int idFabricantes)
        {
            return this.fabricantesRepository.ObtenerPorId(idFabricantes) == null;
        }
    }
}