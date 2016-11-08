// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddLineasProductosValidador.cs" company="">
//   
// </copyright>
// <summary>
//   The add lineasProductos validador.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.LineasProductos
{
    using Dominio.Entidades.Modelos.Productos;
    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add lineasProductos validador.</summary>
    public class AddLineasProductosValidador : AbstractValidator<LineasProductos>
    {
        /// <summary>The lineas productos repository.</summary>
        private readonly IRepositorio<LineasProductos> lineasProductosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddLineasProductosValidador"/> class. Initializes a new instance of the <see cref="LineasProductosValidador"/> class.</summary>
        /// <param name="lineasProductosRepository"></param>
        public AddLineasProductosValidador(IRepositorio<LineasProductos> lineasProductosRepository)
        {
            this.lineasProductosRepository = lineasProductosRepository;
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.IdLineasProductos).Must(this.NoExisteOtroLineasProductos).WithMessage($"Ya existe otro LineasProductos con el mismo identificador");
        }

        /// <summary>The no existe otro lineasProductos.</summary>
        /// <param name="idLineasProductos">The id lineasProductos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroLineasProductos(int idLineasProductos)
        {
            return this.lineasProductosRepository.ObtenerPorId(idLineasProductos) == null;
        }
    }
}