// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTiposProductosValidador.cs" company="">
//   
// </copyright>
// <summary>
//   The add lineasProductos validador.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.TiposProductos
{
    using Dominio.Entidades.Modelos.Productos;
    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add lineasProductos validador.</summary>
    public class AddTiposProductosValidador : AbstractValidator<TiposProductos>
    {
        /// <summary>The lineas productos repository.</summary>
        private readonly IRepositorio<TiposProductos> lineasProductosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddTiposProductosValidador"/> class. Initializes a new instance of the <see cref="TiposProductosValidador"/> class.</summary>
        /// <param name="lineasProductosRepository"></param>
        public AddTiposProductosValidador(IRepositorio<TiposProductos> lineasProductosRepository)
        {
            this.lineasProductosRepository = lineasProductosRepository;
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.IdLineasProductos).NotEmpty().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdTiposProductos).Must(this.NoExisteOtroTiposProductos).WithMessage($"Ya existe otro TiposProductos con el mismo identificador");
        }

        /// <summary>The no existe otro lineasProductos.</summary>
        /// <param name="idTiposProductos">The id lineasProductos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroTiposProductos(int idTiposProductos)
        {
            return this.lineasProductosRepository.ObtenerPorId(idTiposProductos) == null;
        }
    }
}