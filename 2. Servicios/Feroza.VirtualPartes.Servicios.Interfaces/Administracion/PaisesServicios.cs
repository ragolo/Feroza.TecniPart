// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaisesServicios.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the EstadoMaestrasServicios type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using FluentValidation;

    using Validadores.Administracion.Paises;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class PaisesServicios : IPaisesServicio
    {
        /// <summary>The unidad de trabajo administracion.</summary>
        private readonly IUnidadDeTrabajoAdministracion unidadDeTrabajoAdministracion;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="PaisesServicios"/> class.</summary>
        /// <param name="unidadDeTrabajoAdministracion">The unidad De Trabajo Administracion.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public PaisesServicios(IUnidadDeTrabajoAdministracion unidadDeTrabajoAdministracion, IValidatorFactory validatorFactory)
        {
            this.unidadDeTrabajoAdministracion = unidadDeTrabajoAdministracion;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Add(Paises pais)
        {
            var addPaisesValidador = new AddPaisesValidador(this.unidadDeTrabajoAdministracion.PaisesRepositorio);
            var addPaisesValidadorResultado = addPaisesValidador.Validate(pais);

            if (!addPaisesValidadorResultado.IsValid)
            {
                throw new ValidationException(addPaisesValidadorResultado.Errors);
            }

            this.unidadDeTrabajoAdministracion.PaisesRepositorio.Insertar(pais);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Paises pais)
        {
            var editPaisesValidador = new EditPaisesValidador(this.unidadDeTrabajoAdministracion.PaisesRepositorio);
            var editPaisesValidadorResultado = editPaisesValidador.Validate(pais);

            if (!editPaisesValidadorResultado.IsValid)
            {
                throw new ValidationException(editPaisesValidadorResultado.Errors);
            }

            this.unidadDeTrabajoAdministracion.PaisesRepositorio.Actualizar(pais);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The delete pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Delete(Paises pais)
        {
            //TODO: Crear validacion para que no deje borrar un pais si ya fue asignado en la entidad Frabricas
            this.unidadDeTrabajoAdministracion.PaisesRepositorio.Eliminar(pais);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The list pais.</summary>
        /// <param name="idPaises">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Paises Get(int idPaises)
        {
            return this.unidadDeTrabajoAdministracion.PaisesRepositorio.ObtenerPorId(idPaises);
        }

        /// <summary>The list pais.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Paises> List()
        {
            try
            {
                return this.unidadDeTrabajoAdministracion.PaisesRepositorio.Obtener().ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list pais filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<Paises> ListFiltered(Expression<Func<Paises, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoAdministracion.PaisesRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}