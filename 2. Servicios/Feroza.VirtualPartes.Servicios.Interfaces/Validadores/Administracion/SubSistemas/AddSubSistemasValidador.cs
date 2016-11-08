// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSubSistemasValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddSubSistemasValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.SubSistemas
{
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add catalogos validador.</summary>
    public class AddSubSistemasValidador : AbstractValidator<SubSistemas>
    {
        private readonly IRepositorio<SubSistemas> catalogosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddSubSistemasValidador"/> class. Initializes a new instance of the <see cref="SubSistemasValidador"/> class.</summary>
        /// <param name="catalogosRepository"></param>
        public AddSubSistemasValidador(IRepositorio<SubSistemas> catalogosRepository)
        {
            this.catalogosRepository = catalogosRepository;
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdSistemas).NotEmpty();

            this.RuleFor(r => r.IdSubSistemas).Must(this.NoExisteOtroSubSistemas).WithMessage($"Ya existe otro Subsitema con el mismo identificador");
            this.RuleFor(r => r).Must(this.NoExisteOtraDescripcionSubSistemas).WithMessage($"Ya existe otro Sub Sistema con el mismo nombre en el Sistema seleccionado");
            
        }

        /// <summary>The no existe otro catalogos.</summary>
        /// <param name="idSubSistemas">The id catalogos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroSubSistemas(int idSubSistemas)
        {
            return this.catalogosRepository.ObtenerPorId(idSubSistemas) == null;
        }

        /// <summary>The no existe otra descripcion sub sistemas.</summary>
        /// <param name="subSistemas">The sub sistemas.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraDescripcionSubSistemas(SubSistemas subSistemas)
        {
            return !this.catalogosRepository.Obtener(r => r.Descripcion.Equals(subSistemas.Descripcion) && r.IdSistemas.Equals(subSistemas.IdSistemas)).Any();
        }
    }
}