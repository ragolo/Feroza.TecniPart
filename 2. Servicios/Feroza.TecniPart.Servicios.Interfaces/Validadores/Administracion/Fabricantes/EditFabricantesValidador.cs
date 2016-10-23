// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddFabricantesValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddFabricantesValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Fabricantes
{
    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add fabricantes validador.</summary>
    public class EditFabricantesValidador : AbstractValidator<Fabricantes>
    {
        /// <summary>The fabricantes repository.</summary>
        private readonly IRepository<Fabricantes> fabricantesRepository;

        /// <summary>Initializes a new instance of the <see cref="EditFabricantesValidador"/> class. Initializes a new instance of the <see cref="FabricantesValidador"/> class.</summary>
        /// <param name="fabricantesRepository">The fabricantes Repository.</param>
        public EditFabricantesValidador(IRepository<Fabricantes> fabricantesRepository)
        {
            this.fabricantesRepository = fabricantesRepository;
            this.RuleFor(r => r.IdFabricantes).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdPais).NotNull().GreaterThanOrEqualTo(0);
            this.Custom(r => this.NoExisteOtroFabricantes(r));
        }

        /// <summary>The no existe otro fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroFabricantes(Fabricantes fabricantes)
        {
            //if (this.fabricantesRepository.GetFiltered(r => r.IdFabricantes == fabricantes.IdFabricantes && r.Descripcion.Equals(fabricantes.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Fabricantes con el mismo identificador");
            //}

            return null;
        }
    }
}