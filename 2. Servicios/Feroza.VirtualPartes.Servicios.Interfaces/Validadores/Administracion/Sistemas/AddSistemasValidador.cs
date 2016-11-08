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
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add sistemas validador.</summary>
    public class AddSistemasValidador : AbstractValidator<Sistemas>
    {
        /// <summary>The sistemas repository.</summary>
        private readonly IRepositorio<Sistemas> sistemasRepository;

        /// <summary>Initializes a new instance of the <see cref="AddSistemasValidador"/> class. Initializes a new instance of the <see cref="SistemasValidador"/> class.</summary>
        /// <param name="sistemasRepository"></param>
        public AddSistemasValidador(IRepositorio<Sistemas> sistemasRepository)
        {
            this.sistemasRepository = sistemasRepository;
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.Posicion).GreaterThanOrEqualTo(1);

            this.RuleFor(r => r.Descripcion).Must(this.NoExisteOtraDescripcionSistemas).WithMessage($"Ya existe otra Sistema con el mismo nombre");
            this.RuleFor(r => r.IdSistemas).Must(this.NoExisteOtroSistemas).WithMessage($"Ya existe otro Pais con el mismo identificador");
        }

        /// <summary>The no existe otro sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroSistemas(int idSistemas)
        {
            return this.sistemasRepository.ObtenerPorId(idSistemas) == null;
        }

        /// <summary>The no existe otra descripcion sistemas.</summary>
        /// <param name="descripcion">The descripcion.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraDescripcionSistemas(string descripcion)
        {
            return !this.sistemasRepository.Obtener(r => r.Descripcion.Equals(descripcion)).Any();
        }
    }
}