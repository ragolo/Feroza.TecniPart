// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddReferenciasValidador.cs" company="">
//   
// </copyright>
// <summary>
//   The add referencias validador.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Referencias
{
    using System.Linq;

    using Dominio.Entidades.Modelos.Referencias;
    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add referencias validador.</summary>
    public class AddReferenciasValidador : AbstractValidator<Referencias>
    {
        /// <summary>The referencias repository.</summary>
        private readonly IRepositorio<Referencias> referenciasRepository;

        /// <summary>Initializes a new instance of the <see cref="AddReferenciasValidador"/> class.</summary>
        /// <param name="referenciasRepository">The referencias repository.</param>
        public AddReferenciasValidador(IRepositorio<Referencias> referenciasRepository)
        {
            this.referenciasRepository = referenciasRepository;
            this.RuleFor(r => r.CodigoOEM).NotEmpty();
            this.RuleFor(r => r.EsKit).NotNull();
            this.RuleFor(r => r.IdMarcasTiposProductos).NotNull();
            this.RuleFor(r => r.IdMarcasTiposProductos).Must(r => r >= 1).WithMessage("Por favor seleccionar marcas tipos productos");

            this.RuleFor(r => r.Descripcion).Must(this.NoExisteOtraDescripcionReferencia).WithMessage($"Ya existe otra Marca con el mismo nombre");
        }

        /// <summary>The no existe otro referencias.</summary>
        /// <param name="codigoOem">The codigo Oem.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraReferencias(string codigoOem)
        {
            return this.referenciasRepository.ObtenerPorId(codigoOem) == null;
        }

        /// <summary>The no existe otra descripcion referencia.</summary>
        /// <param name="descripcion">The descripcion.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraDescripcionReferencia(string descripcion)
        {
            return !this.referenciasRepository.Obtener(r => r.Descripcion.Equals(descripcion)).Any();
        }
    }
}