// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddReferenciasValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddReferenciasValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Referencias
{
    using Dominio.Entidades.Modelos.Referencias;
    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add referencias validador.</summary>
    public class EditReferenciasValidador : AbstractValidator<Referencias>
    {
        /// <summary>The referencias repository.</summary>
        private readonly IRepositorio<Referencias> referenciasRepository;

        /// <summary>Initializes a new instance of the <see cref="EditReferenciasValidador"/> class. Initializes a new instance of the <see cref="ReferenciasValidador"/> class.</summary>
        /// <param name="referenciasRepository">The referencias Repository.</param>
        public EditReferenciasValidador(IRepositorio<Referencias> referenciasRepository)
        {
            this.referenciasRepository = referenciasRepository;
            this.RuleFor(r => r.CodigoOEM).NotEmpty();
            this.RuleFor(r => r.EsKit).NotNull();
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdMarcasTiposProductos).NotNull();
        }
    }
}