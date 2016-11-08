// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosServicios.cs" company="">
//   
// </copyright>
// <summary>
//   The estado maestras servicios.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Administracion.Producto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Dominio.Entidades.Modelos.Productos;
    using Dominio.Interfaces.Administracion.Productos;

    using FluentValidation;

    using Validadores.Administracion.Producto.Productos;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class ProductosServicios : IProductosServicio
    {
        /// <summary>The productos repositorio.</summary>
        private readonly IUnidadDeTrabajoProductos unidadDeTrabajoProductos;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="ProductosServicios"/> class.</summary>
        /// <param name="unidadDeTrabajoProductos.ProductosRepositorio">The productos repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public ProductosServicios(IUnidadDeTrabajoProductos unidadDeTrabajoProductos, IValidatorFactory validatorFactory)
        {
            this.unidadDeTrabajoProductos = unidadDeTrabajoProductos;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add productos.</summary>
        /// <param name="productos">The productos.</param>
        public void Add(Productos productos)
        {
            var addProductosValidador = new AddProductosValidador(this.unidadDeTrabajoProductos.ProductosRepositorio);
            var addProductosValidadorResultado = addProductosValidador.Validate(productos);

            if (!addProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(addProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.ProductosRepositorio.Insertar(productos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The edit productos.</summary>
        /// <param name="productos">The productos.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Productos productos)
        {
            var editProductosValidador = new EditProductosValidador(this.unidadDeTrabajoProductos.ProductosRepositorio);
            var editProductosValidadorResultado = editProductosValidador.Validate(productos);

            if (!editProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(editProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.ProductosRepositorio.Actualizar(productos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The delete productos.</summary>
        /// <param name="productos">The productos.</param>
        public void Delete(Productos productos)
        {
            this.unidadDeTrabajoProductos.ProductosRepositorio.Eliminar(productos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The list productos.</summary>
        /// <param name="idProductos">The id productos.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Productos Get(int idProductos)
        {
            return this.unidadDeTrabajoProductos.ProductosRepositorio.ObtenerPorId(idProductos);
        }

        /// <summary>The list productos.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Productos> List()
        {
            try
            {
                return this.unidadDeTrabajoProductos.ProductosRepositorio.ObtenerTodo().ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list productos filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<Productos> ListFiltered(Expression<Func<Productos, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoProductos.ProductosRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}