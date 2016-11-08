
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasTiposProductosServicios .cs" company="">
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

    using Validadores.Administracion.Producto.MarcasTiposProductos;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class MarcasTiposProductosServicios : IMarcasTiposProductosServicio
    {
        /// <summary>The marcasTiposProductos repositorio.</summary>
        private readonly IUnidadDeTrabajoProductos unidadDeTrabajoProductos;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="MarcasTiposProductosServicios "/> class.</summary>
        /// <param name="unidadDeTrabajoProductos.MarcasTiposProductosRepositorio">The marcasTiposProductos repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public MarcasTiposProductosServicios (IUnidadDeTrabajoProductos unidadDeTrabajoProductos, IValidatorFactory validatorFactory)
        {
            this.unidadDeTrabajoProductos = unidadDeTrabajoProductos;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add marcasTiposProductos.</summary>
        /// <param name="marcasTiposProductos">The marcasTiposProductos.</param>
        public void Add(MarcasTiposProductos marcasTiposProductos)
        {
            var addMarcasTiposProductosValidador = new AddMarcasTiposProductosValidador(this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio);
            var addMarcasTiposProductosValidadorResultado = addMarcasTiposProductosValidador.Validate(marcasTiposProductos);

            if (!addMarcasTiposProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(addMarcasTiposProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio.Insertar(marcasTiposProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The edit marcasTiposProductos.</summary>
        /// <param name="marcasTiposProductos">The marcasTiposProductos.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(MarcasTiposProductos marcasTiposProductos)
        {
            var editMarcasTiposProductosValidador = new EditMarcasTiposProductosValidador(this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio);
            var editMarcasTiposProductosValidadorResultado = editMarcasTiposProductosValidador.Validate(marcasTiposProductos);

            if (!editMarcasTiposProductosValidadorResultado.IsValid)
            {
                throw new ValidationException(editMarcasTiposProductosValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio.Actualizar(marcasTiposProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The delete marcasTiposProductos.</summary>
        /// <param name="marcasTiposProductos">The marcasTiposProductos.</param>
        public void Delete(MarcasTiposProductos marcasTiposProductos)
        {
            this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio.Eliminar(marcasTiposProductos);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The list marcasTiposProductos.</summary>
        /// <param name="idMarcasTiposProductos">The id marcasTiposProductos.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public MarcasTiposProductos Get(int idMarcasTiposProductos)
        {
            return this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio.ObtenerPorId(idMarcasTiposProductos);
        }

        /// <summary>The list marcasTiposProductos.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<MarcasTiposProductos> List()
        {
            try
            {
                return this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio.Obtener(null, null, productos => productos.TiposProductos, productos => productos.Marcas).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list marcasTiposProductos filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<MarcasTiposProductos> ListFiltered(Expression<Func<MarcasTiposProductos, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The obtener lista tipos productos por marcas tipos.</summary>
        /// <returns>The <see cref="IList"/>.</returns>
        public IList<LineasProductos> ObtenerListaTiposProductosPorMarcasTipos()
        {
            var idTiposProductosMarcasTipos = this.unidadDeTrabajoProductos.MarcasTiposProductosRepositorio.Obtener().ToArray().Select(r => r.IdTiposProductos);
            return this.unidadDeTrabajoProductos.LineasProductosRepositorio.Obtener(productos => productos.TiposProductos.Any(r => idTiposProductosMarcasTipos.Contains(r.IdTiposProductos))).ToList();
        }
    }
}