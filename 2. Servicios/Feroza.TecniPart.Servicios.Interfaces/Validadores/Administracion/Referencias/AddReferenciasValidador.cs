// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddReferenciasValidador.cs" company="">
//   
// </copyright>
// <summary>
//   The add referencias validador.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Referencias
{
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;

    /// <summary>The add referencias validador.</summary>
    public class AddReferenciasValidador : AbstractValidator<Referencias>
    {
        /// <summary>The referencias repository.</summary>
        private readonly IRepository<Referencias> referenciasRepository;

        /// <summary>Initializes a new instance of the <see cref="AddReferenciasValidador"/> class.</summary>
        /// <param name="referenciasRepository">The referencias repository.</param>
        public AddReferenciasValidador(IRepository<Referencias> referenciasRepository)
        {
            this.referenciasRepository = referenciasRepository;
            this.RuleFor(r => r.CodigoOem).NotEmpty();
            this.RuleFor(r => r.Kit).NotNull();
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdMarcas).NotNull();
            this.RuleFor(r => r.IdSistemas).NotNull();
            this.RuleFor(r => r.IdSubSistemas).NotNull();

            this.RuleFor(r => r.CodigoOem).Must(this.NoExisteOtraReferencias).WithMessage($"Ya existe otro Codigo OEM");
            this.RuleFor(r => r.Descripcion).Must(this.NoExisteOtraDescripcionReferencia).WithMessage($"Ya existe otra Marca con el mismo nombre");
        }

        /// <summary>The no existe otro referencias.</summary>
        /// <param name="codigoOem">The codigo Oem.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraReferencias(string codigoOem)
        {
            return this.referenciasRepository.GetById(codigoOem) == null;
        }

        /// <summary>The no existe otra descripcion referencia.</summary>
        /// <param name="descripcion">The descripcion.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraDescripcionReferencia(string descripcion)
        {
            return !this.referenciasRepository.GetFiltered(r => r.Descripcion.Equals(descripcion)).Any();
        }
    }
}