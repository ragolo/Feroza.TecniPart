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

    /// <summary>The add catalogos validador.</summary>
    public class AddCatalogosValidador : AbstractValidator<Catalogos>
    {
        /// <summary>The catalogos repository.</summary>
        private readonly IRepository<Catalogos> catalogosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddCatalogosValidador"/> class. Initializes a new instance of the <see cref="CatalogosValidador"/> class.</summary>
        /// <param name="catalogosRepository"></param>
        public AddCatalogosValidador(IRepository<Catalogos> catalogosRepository)
        {
            this.catalogosRepository = catalogosRepository;
            this.RuleFor(r => r.IdVehiculos).NotNull();
            this.RuleFor(r => r.IdSistemas).NotNull();
            this.RuleFor(r => r.IdSubSistemas).NotNull();
            this.RuleFor(r => r.IdCatalogos).Must(this.NoExisteOtroCatalogos).WithMessage($"Ya existe otro Catalogo con el mismo identificador");

        }

        /// <summary>The no existe otro catalogos.</summary>
        /// <param name="idCatalogos">The id catalogos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroCatalogos(long idCatalogos)
        {
            return this.catalogosRepository.GetById(idCatalogos) == null;
        }
    }
}