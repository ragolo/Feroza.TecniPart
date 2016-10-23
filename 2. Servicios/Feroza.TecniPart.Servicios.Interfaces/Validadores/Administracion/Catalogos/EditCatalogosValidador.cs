// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddCatalogosValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddCatalogosValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Catalogos
{
    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add fabricantes validador.</summary>
    public class EditCatalogosValidador : AbstractValidator<Catalogos>
    {
        /// <summary>The fabricantes repository.</summary>
        private readonly IRepository<Catalogos> fabricantesRepository;

        /// <summary>Initializes a new instance of the <see cref="EditCatalogosValidador"/> class. Initializes a new instance of the <see cref="CatalogosValidador"/> class.</summary>
        /// <param name="fabricantesRepository">The fabricantes Repository.</param>
        public EditCatalogosValidador(IRepository<Catalogos> fabricantesRepository)
        {
            this.fabricantesRepository = fabricantesRepository;
            this.RuleFor(r => r.IdCatalogos).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdSistemas).NotEmpty();
            this.RuleFor(r => r.IdSubSistemas).NotEmpty();
            this.Custom(r => this.NoExisteOtroCatalogos(r));
        }

        /// <summary>The no existe otro fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroCatalogos(Catalogos fabricantes)
        {
            //if (this.fabricantesRepository.GetFiltered(r => r.IdCatalogos == fabricantes.IdCatalogos && r.Descripcion.Equals(fabricantes.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Catalogos con el mismo identificador");
            //}

            return null;
        }
    }
}