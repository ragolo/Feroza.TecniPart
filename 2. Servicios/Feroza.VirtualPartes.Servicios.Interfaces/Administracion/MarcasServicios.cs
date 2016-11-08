// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasServicios.cs" company="Feroza">
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

    using Validadores.Administracion.Marcas;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class MarcasServicios : IMarcasServicio
    {
        /// <summary>The unidad de trabajo administracion.</summary>
        private readonly IUnidadDeTrabajoAdministracion unidadDeTrabajoAdministracion;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="MarcasServicios"/> class.</summary>
        /// <param name="validatorFactory">The validator Factory.</param>
        public MarcasServicios(IUnidadDeTrabajoAdministracion unidadDeTrabajoAdministracion, IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
            this.unidadDeTrabajoAdministracion = unidadDeTrabajoAdministracion;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Add(Marcas pais)
        {
            var addMarcasValidador = new AddMarcasValidador(this.unidadDeTrabajoAdministracion.MarcasRepositorio);
            var addMarcasValidadorResultado = addMarcasValidador.Validate(pais);

            if (!addMarcasValidadorResultado.IsValid)
            {
                throw new ValidationException(addMarcasValidadorResultado.Errors);
            }

            this.unidadDeTrabajoAdministracion.MarcasRepositorio.Insertar(pais);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Marcas pais)
        {
            var editMarcasValidador = new EditMarcasValidador(this.unidadDeTrabajoAdministracion.MarcasRepositorio);
            var editMarcasValidadorResultado = editMarcasValidador.Validate(pais);

            if (!editMarcasValidadorResultado.IsValid)
            {
                throw new ValidationException(editMarcasValidadorResultado.Errors);
            }

            this.unidadDeTrabajoAdministracion.MarcasRepositorio.Actualizar(pais);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The delete pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Delete(Marcas pais)
        {
            //TODO: Crear validacion para que no deje borrar un pais si ya fue asignado en la entidad Frabricas
            this.unidadDeTrabajoAdministracion.MarcasRepositorio.Eliminar(pais);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The list pais.</summary>
        /// <param name="idMarcas">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Marcas Get(int idMarcas)
        {
            return this.unidadDeTrabajoAdministracion.MarcasRepositorio.ObtenerPorId(idMarcas);
        }

        /// <summary>The list pais.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Marcas> List()
        {
            try
            {
                return this.unidadDeTrabajoAdministracion.MarcasRepositorio.Obtener(null, null, marcas => marcas.Fabricantes).ToArray();
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
        public IList<Marcas> ListFiltered(Expression<Func<Marcas, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoAdministracion.MarcasRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}