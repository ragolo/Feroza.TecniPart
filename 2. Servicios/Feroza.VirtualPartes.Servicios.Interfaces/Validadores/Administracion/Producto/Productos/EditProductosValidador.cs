// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddProductosValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddProductosValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.Productos
{
    using System;

    using Dominio.Entidades.Modelos.Productos;

    using Dominio.RepositorioContratos;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add productos validador.</summary>
    public class EditProductosValidador : AbstractValidator<Productos>
    {
        /// <summary>The productos repository.</summary>
        private readonly IRepositorio<Productos> productosRepository;

        /// <summary>Initializes a new instance of the <see cref="EditProductosValidador"/> class. Initializes a new instance of the <see cref="ProductosValidador"/> class.</summary>
        /// <param name="productosRepository">The productos Repository.</param>
        public EditProductosValidador(IRepositorio<Productos> productosRepository)
        {
            this.productosRepository = productosRepository;
            this.RuleFor(r => r.IdProductos).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.IdMarcasTiposProductos).NotNull().GreaterThanOrEqualTo(1);
            this.RuleFor(r => r.Anio).NotNull().GreaterThanOrEqualTo(DateTime.MinValue.Year);
            this.Custom(r => this.NoExisteOtroProductos(r));
        }

        /// <summary>The no existe otro productos.</summary>
        /// <param name="productos">The productos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroProductos(Productos productos)
        {
            //if (this.productosRepository.GetFiltered(r => r.IdProductos == productos.IdProductos && r.Descripcion.Equals(productos.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Productos con el mismo identificador");
            //}

            return null;
        }
    }
}