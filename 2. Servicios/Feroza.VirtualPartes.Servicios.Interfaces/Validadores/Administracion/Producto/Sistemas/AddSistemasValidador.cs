// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSistemasValidador.cs" company="">
//   
// </copyright>
// <summary>
//   The add sistemas validador.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.Sistemas
{
    using Dominio.Entidades.Modelos.Productos;
    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add sistemas validador.</summary>
    public class AddSistemasValidador : AbstractValidator<Sistemas>
    {
        /// <summary>The lineas productos repository.</summary>
        private readonly IRepositorio<Sistemas> sistemasRepository;

        /// <summary>Initializes a new instance of the <see cref="AddSistemasValidador"/> class. Initializes a new instance of the <see cref="SistemasValidador"/> class.</summary>
        /// <param name="sistemasRepository"></param>
        public AddSistemasValidador(IRepositorio<Sistemas> sistemasRepository)
        {
            this.sistemasRepository = sistemasRepository;
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.IdSistemas).Must(this.NoExisteOtroSistemas).WithMessage($"Ya existe otro Sistemas con el mismo identificador");
        }

        /// <summary>The no existe otro sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroSistemas(int idSistemas)
        {
            return this.sistemasRepository.ObtenerPorId(idSistemas) == null;
        }
    }
}