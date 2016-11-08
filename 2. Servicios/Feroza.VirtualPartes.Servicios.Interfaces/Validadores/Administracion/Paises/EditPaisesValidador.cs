// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPaisesValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddPaisesValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Paises
{

    using Dominio.Entidades.Modelos;

    using Dominio.RepositorioContratos;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add pais validador.</summary>
    public class EditPaisesValidador : AbstractValidator<Paises>
    {
        /// <summary>The pais repository.</summary>
        private readonly IRepositorio<Paises> paisRepository;

        /// <summary>Initializes a new instance of the <see cref="EditPaisesValidador"/> class. Initializes a new instance of the <see cref="PaisesValidador"/> class.</summary>
        /// <param name="paisRepository">The pais Repository.</param>
        public EditPaisesValidador(IRepositorio<Paises> paisRepository)
        {
            this.paisRepository = paisRepository;
            this.RuleFor(r => r.IdPaises).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.CodigoDian).NotEmpty();
            this.Custom(this.NoExisteOtroPaises);
        }

        /// <summary>The no existe otro pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroPaises(Paises pais)
        {
            //if (this.paisRepository.GetFiltered(r => r.IdPaises == pais.IdPaises && r.Descripcion.Equals(pais.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Paises con el mismo identificador");
            //}

            return null;
        }
    }
}