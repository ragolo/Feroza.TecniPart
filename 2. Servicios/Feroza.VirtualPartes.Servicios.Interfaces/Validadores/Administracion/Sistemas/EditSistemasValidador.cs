// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSistemasValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddSistemasValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Sistemas
{
    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.RepositorioContratos;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add fabricantes validador.</summary>
    public class EditSistemasValidador : AbstractValidator<Sistemas>
    {
        /// <summary>The fabricantes repository.</summary>
        private readonly IRepositorio<Sistemas> fabricantesRepository;

        /// <summary>Initializes a new instance of the <see cref="EditSistemasValidador"/> class. Initializes a new instance of the <see cref="SistemasValidador"/> class.</summary>
        /// <param name="fabricantesRepository">The fabricantes Repository.</param>
        public EditSistemasValidador(IRepositorio<Sistemas> fabricantesRepository)
        {
            this.fabricantesRepository = fabricantesRepository;
            this.RuleFor(r => r.IdSistemas).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdSistemas).NotEmpty();
            this.RuleFor(r => r.Posicion).NotEmpty();
            this.Custom(r => this.NoExisteOtroSistemas(r));
        }

        /// <summary>The no existe otro fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroSistemas(Sistemas fabricantes)
        {
            //if (this.fabricantesRepository.GetFiltered(r => r.IdSistemas == fabricantes.IdSistemas && r.Descripcion.Equals(fabricantes.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Sistemas con el mismo identificador");
            //}

            return null;
        }
    }
}