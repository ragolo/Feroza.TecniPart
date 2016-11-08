// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddProductosValidador.cs" company="">
//   
// </copyright>
// <summary>
//   The add productos validador.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.Productos
{
    using System;

    using Dominio.Entidades.Modelos.Productos;
    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add productos validador.</summary>
    public class AddProductosValidador : AbstractValidator<Productos>
    {
        /// <summary>The lineas productos repository.</summary>
        private readonly IRepositorio<Productos> productosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddProductosValidador"/> class. Initializes a new instance of the <see cref="ProductosValidador"/> class.</summary>
        /// <param name="productosRepository"></param>
        public AddProductosValidador(IRepositorio<Productos> productosRepository)
        {
            this.productosRepository = productosRepository;
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.IdMarcasTiposProductos).NotNull().GreaterThanOrEqualTo(1);
            this.RuleFor(r => r.Anio).NotNull().GreaterThanOrEqualTo(DateTime.MinValue.Year);
            this.RuleFor(r => r.IdProductos).Must(this.NoExisteOtroProductos).WithMessage($"Ya existe otro Productos con el mismo identificador");
        }

        /// <summary>The no existe otro productos.</summary>
        /// <param name="idProductos">The id productos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroProductos(int idProductos)
        {
            return this.productosRepository.ObtenerPorId(idProductos) == null;
        }
    }
}