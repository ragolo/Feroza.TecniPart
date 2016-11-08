
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TiposProductosServicios .cs" company="">
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

    using Validadores.Administracion.Producto.TiposProductos;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class TiposProductosServicios  : ITiposProductosServicio
    {
        /// <summary>The lineasProductos repositorio.</summary>
        private readonly IUnidadDeTrabajoProductos unidadDeTrabajoProductos;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="TiposProductosServicios "/> class.</summary>
        /// <param name="unidadDeTrabajoProductos.TiposProductosRepositorio">The lineasProductos repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public TiposProductosServicios (IUnidadDeTrabajoProductos unidadDeTrabajoProductos, IValidatorFactory validatorFactory)
        {
            this.unidadDeTrabajoProductos = unidadDeTrabajoProductos;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        public void Add(TiposProductos lineasProductos)
        {
            var addTiposProductosValidador = new AddTiposProductosValidador(this.unidadDeTrabajoProductos.TiposProductosRepositorio);
            var addTiposProductosValidadorResultado = addTiposProductosValidador.Validate(lineasProductos);

            if (!addTiposProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(addTiposProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.TiposProductosRepositorio.Insertar(lineasProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The edit lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(TiposProductos lineasProductos)
        {
            var editTiposProductosValidador = new EditTiposProductosValidador(this.unidadDeTrabajoProductos.TiposProductosRepositorio);
            var editTiposProductosValidadorResultado = editTiposProductosValidador.Validate(lineasProductos);

            if (!editTiposProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(editTiposProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.TiposProductosRepositorio.Actualizar(lineasProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The delete lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        public void Delete(TiposProductos lineasProductos)
        {
            this.unidadDeTrabajoProductos.TiposProductosRepositorio.Eliminar(lineasProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The list lineasProductos.</summary>
        /// <param name="idTiposProductos">The id lineasProductos.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public TiposProductos Get(int idTiposProductos)
        {
            return this.unidadDeTrabajoProductos.TiposProductosRepositorio.ObtenerPorId(idTiposProductos);
        }

        /// <summary>The list lineasProductos.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<TiposProductos> List()
        {
            try
            {
                return this.unidadDeTrabajoProductos.TiposProductosRepositorio.Obtener(null, null, productos => productos.LineasProductos).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list lineasProductos filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<TiposProductos> ListFiltered(Expression<Func<TiposProductos, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoProductos.TiposProductosRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}