// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPaisValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddPaisValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Pais
{
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add pais validador.</summary>
    public class EditPaisValidador : AbstractValidator<Pais>
    {
        /// <summary>The pais repository.</summary>
        private readonly IRepository<Pais> paisRepository;

        /// <summary>Initializes a new instance of the <see cref="EditPaisValidador"/> class. Initializes a new instance of the <see cref="PaisValidador"/> class.</summary>
        /// <param name="paisRepository">The pais Repository.</param>
        public EditPaisValidador(IRepository<Pais> paisRepository)
        {
            this.paisRepository = paisRepository;
            this.RuleFor(r => r.IdPais).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdDane).NotEmpty();
            this.Custom(r => this.NoExisteOtroPais(r));
        }

        /// <summary>The no existe otro pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroPais(Pais pais)
        {
            //if (this.paisRepository.GetFiltered(r => r.IdPais == pais.IdPais && r.Descripcion.Equals(pais.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Pais con el mismo identificador");
            //}

            return null;
        }
    }
}