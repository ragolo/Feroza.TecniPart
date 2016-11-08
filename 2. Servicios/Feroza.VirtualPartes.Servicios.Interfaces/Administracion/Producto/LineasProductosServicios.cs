// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineasProductosServicios.cs" company="">
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

    using Validadores.Administracion.Producto.LineasProductos;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class LineasProductosServicios : ILineasProductosServicio
    {
        /// <summary>The lineasProductos repositorio.</summary>
        private readonly IUnidadDeTrabajoProductos unidadDeTrabajoProductos;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="LineasProductosServicios"/> class.</summary>
        /// <param name="unidadDeTrabajoProductos.LineasProductosRepositorio">The lineasProductos repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public LineasProductosServicios(IUnidadDeTrabajoProductos unidadDeTrabajoProductos, IValidatorFactory validatorFactory)
        {
            this.unidadDeTrabajoProductos = unidadDeTrabajoProductos;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        public void Add(LineasProductos lineasProductos)
        {
            var addLineasProductosValidador = new AddLineasProductosValidador(this.unidadDeTrabajoProductos.LineasProductosRepositorio);
            var addLineasProductosValidadorResultado = addLineasProductosValidador.Validate(lineasProductos);

            if (!addLineasProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(addLineasProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.LineasProductosRepositorio.Insertar(lineasProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The edit lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(LineasProductos lineasProductos)
        {
            var editLineasProductosValidador = new EditLineasProductosValidador(this.unidadDeTrabajoProductos.LineasProductosRepositorio);
            var editLineasProductosValidadorResultado = editLineasProductosValidador.Validate(lineasProductos);

            if (!editLineasProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(editLineasProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.LineasProductosRepositorio.Actualizar(lineasProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The delete lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        public void Delete(LineasProductos lineasProductos)
        {
            this.unidadDeTrabajoProductos.LineasProductosRepositorio.Eliminar(lineasProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The list lineasProductos.</summary>
        /// <param name="idLineasProductos">The id lineasProductos.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public LineasProductos Get(int idLineasProductos)
        {
            return this.unidadDeTrabajoProductos.LineasProductosRepositorio.ObtenerPorId(idLineasProductos);
        }

        /// <summary>The list lineasProductos.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<LineasProductos> List()
        {
            try
            {
                return this.unidadDeTrabajoProductos.LineasProductosRepositorio.ObtenerTodo().ToArray();
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
        public IList<LineasProductos> ListFiltered(Expression<Func<LineasProductos, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoProductos.LineasProductosRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}