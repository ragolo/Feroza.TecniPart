// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesServicios.cs" company="Feroza">
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

    using Validadores.Administracion.Fabricantes;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class FabricantesServicios : IFabricantesServicio
    {
        /// <summary>The unidad de trabajo administracion.</summary>
        private readonly IUnidadDeTrabajoAdministracion unidadDeTrabajoAdministracion;


        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="FabricantesServicios"/> class.</summary>
        /// <param name="validatorFactory">The validator Factory.</param>
        public FabricantesServicios(IUnidadDeTrabajoAdministracion unidadDeTrabajoAdministracion, IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
            this.unidadDeTrabajoAdministracion = unidadDeTrabajoAdministracion;
        }

        /// <summary>The add fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        public void Add(Fabricantes fabricantes)
        {
            var addFabricantesValidador = new AddFabricantesValidador(this.unidadDeTrabajoAdministracion.FabricantesRepositorio);
            var addFabricantesValidadorResultado = addFabricantesValidador.Validate(fabricantes);

            if (!addFabricantesValidadorResultado.IsValid)
            {
                throw new ValidationException(addFabricantesValidadorResultado.Errors);
            }

            this.unidadDeTrabajoAdministracion.FabricantesRepositorio.Insertar(fabricantes);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The edit fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Fabricantes fabricantes)
        {
            var editFabricantesValidador = new EditFabricantesValidador(this.unidadDeTrabajoAdministracion.FabricantesRepositorio);
            var editFabricantesValidadorResultado = editFabricantesValidador.Validate(fabricantes);

            if (!editFabricantesValidadorResultado.IsValid)
            {
                throw new ValidationException(editFabricantesValidadorResultado.Errors);
            }

            this.unidadDeTrabajoAdministracion.FabricantesRepositorio.Actualizar(fabricantes);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The delete fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        public void Delete(Fabricantes fabricantes)
        {
            //TODO: Crear validacion para que no deje borrar un fabricantes si ya fue asignado en la entidad Frabricas
            this.unidadDeTrabajoAdministracion.FabricantesRepositorio.Eliminar(fabricantes);
            this.unidadDeTrabajoAdministracion.Confirmar();
        }

        /// <summary>The list fabricantes.</summary>
        /// <param name="idFabricantes">The id fabricantes.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Fabricantes Get(int idFabricantes)
        {
            return this.unidadDeTrabajoAdministracion.FabricantesRepositorio.ObtenerPorId(idFabricantes);
        }

        /// <summary>The list fabricantes.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Fabricantes> List()
        {
            try
            {
                return this.unidadDeTrabajoAdministracion.FabricantesRepositorio.Obtener(null, null, fabricantes => fabricantes.Paises).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list fabricantes filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<Fabricantes> ListFiltered(Expression<Func<Fabricantes, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoAdministracion.FabricantesRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}