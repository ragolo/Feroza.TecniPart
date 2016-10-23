// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSubSistemasValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddSubSistemasValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.SubSistemas
{
    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add fabricantes validador.</summary>
    public class EditSubSistemasValidador : AbstractValidator<SubSistemas>
    {
        /// <summary>The fabricantes repository.</summary>
        private readonly IRepository<SubSistemas> fabricantesRepository;

        /// <summary>Initializes a new instance of the <see cref="EditSubSistemasValidador"/> class. Initializes a new instance of the <see cref="SubSistemasValidador"/> class.</summary>
        /// <param name="fabricantesRepository">The fabricantes Repository.</param>
        public EditSubSistemasValidador(IRepository<SubSistemas> fabricantesRepository)
        {
            this.fabricantesRepository = fabricantesRepository;
            this.RuleFor(r => r.IdSubSistemas).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdSubSistemas).NotEmpty();
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.Custom(r => this.NoExisteOtroSubSistemas(r));
        }

        /// <summary>The no existe otro fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroSubSistemas(SubSistemas fabricantes)
        {
            //if (this.fabricantesRepository.GetFiltered(r => r.IdSubSistemas == fabricantes.IdSubSistemas && r.Descripcion.Equals(fabricantes.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro SubSistemas con el mismo identificador");
            //}

            return null;
        }
    }
}