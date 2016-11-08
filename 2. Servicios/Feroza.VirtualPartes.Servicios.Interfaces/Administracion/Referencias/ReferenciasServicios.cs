// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenciasServicios.cs" company="">
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

    using Dominio.Entidades.Modelos.Referencias;
    using Dominio.Interfaces.Administracion.Referencias;

    using FluentValidation;

    using Validadores.Administracion.Referencias;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class ReferenciasServicios : IReferenciasServicio
    {
        /// <summary>The referencias repositorio.</summary>
        private readonly IUnidadDeTrabajoReferencias unidadDeTrabajoReferencias;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="ReferenciasServicios"/> class.</summary>
        /// <param name="unidadDeTrabajoReferencias.ReferenciasRepositorio">The referencias repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public ReferenciasServicios(IUnidadDeTrabajoReferencias unidadDeTrabajoReferencias, IValidatorFactory validatorFactory)
        {
            this.unidadDeTrabajoReferencias = unidadDeTrabajoReferencias;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        public void Add(Referencias referencias)
        {
            var addReferenciasValidador = new AddReferenciasValidador(this.unidadDeTrabajoReferencias.ReferenciasRepositorio);
            var addReferenciasValidadorResultado = addReferenciasValidador.Validate(referencias);

            if (!addReferenciasValidadorResultado.IsValid)
            {
                throw new ValidationException(addReferenciasValidadorResultado.Errors);
            }
            referencias.MarcasTiposProductos = null;
            this.unidadDeTrabajoReferencias.ReferenciasRepositorio.Insertar(referencias);
            this.unidadDeTrabajoReferencias.Confirmar();
        }

        /// <summary>The edit referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Referencias referencias)
        {
            var editReferenciasValidador = new EditReferenciasValidador(this.unidadDeTrabajoReferencias.ReferenciasRepositorio);
            var editReferenciasValidadorResultado = editReferenciasValidador.Validate(referencias);

            if (!editReferenciasValidadorResultado.IsValid)
            {
                throw new ValidationException(editReferenciasValidadorResultado.Errors);
            }

            this.unidadDeTrabajoReferencias.ReferenciasRepositorio.Actualizar(referencias);
            this.unidadDeTrabajoReferencias.Confirmar();
        }

        /// <summary>The delete referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        public void Delete(Referencias referencias)
        {
            this.unidadDeTrabajoReferencias.ReferenciasRepositorio.Eliminar(referencias);
            this.unidadDeTrabajoReferencias.Confirmar();
        }

        /// <summary>The list referencias.</summary>
        /// <param name="idReferencias">The id referencias.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Referencias Get(int idReferencias)
        {
            return this.unidadDeTrabajoReferencias.ReferenciasRepositorio.ObtenerPorId(idReferencias);
        }

        /// <summary>The list referencias.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Referencias> List()
        {
            try
            {
                return this.unidadDeTrabajoReferencias.ReferenciasRepositorio.Obtener(null, null, referencias => referencias.MarcasTiposProductos.Marcas, referencias => referencias.MarcasTiposProductos.TiposProductos).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list referencias filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<Referencias> ListFiltered(Expression<Func<Referencias, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoReferencias.ReferenciasRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}