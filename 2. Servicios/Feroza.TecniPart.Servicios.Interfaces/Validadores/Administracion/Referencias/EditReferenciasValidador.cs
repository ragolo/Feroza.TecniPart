// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddReferenciasValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddReferenciasValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Referencias
{
    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;

    /// <summary>The add referencias validador.</summary>
    public class EditReferenciasValidador : AbstractValidator<Referencias>
    {
        /// <summary>The referencias repository.</summary>
        private readonly IRepository<Referencias> referenciasRepository;

        /// <summary>Initializes a new instance of the <see cref="EditReferenciasValidador"/> class. Initializes a new instance of the <see cref="ReferenciasValidador"/> class.</summary>
        /// <param name="referenciasRepository">The referencias Repository.</param>
        public EditReferenciasValidador(IRepository<Referencias> referenciasRepository)
        {
            this.referenciasRepository = referenciasRepository;
            this.RuleFor(r => r.CodigoOem).NotEmpty();
            this.RuleFor(r => r.Kit).NotNull();
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdMarcas).NotNull();
        }
    }
}