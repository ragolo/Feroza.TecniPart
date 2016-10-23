// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesServicios.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the EstadoMaestrasServicios type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;
    using Dominio.Interfaces.Repositorio;

    using FluentValidation;

    using Validadores.Administracion.Fabricantes;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class FabricantesServicios : IFabricantesServicio
    {
        /// <summary>The fabricantes repositorio.</summary>
        private readonly IRepository<Fabricantes> fabricantesRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="FabricantesServicios"/> class.</summary>
        /// <param name="fabricantesRepositorio">The fabricantes repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public FabricantesServicios(IRepository<Fabricantes> fabricantesRepositorio, IValidatorFactory validatorFactory)
        {
            this.fabricantesRepositorio = fabricantesRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        public void Add(Fabricantes fabricantes)
        {
            var addFabricantesValidador = new AddFabricantesValidador(this.fabricantesRepositorio);
            var addFabricantesValidadorResultado = addFabricantesValidador.Validate(fabricantes);

            if (!addFabricantesValidadorResultado.IsValid)
            {
                throw new ValidationException(addFabricantesValidadorResultado.Errors);
            }

            this.fabricantesRepositorio.Insert(fabricantes);
        }

        /// <summary>The edit fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Fabricantes fabricantes)
        {
            var editFabricantesValidador = new EditFabricantesValidador(this.fabricantesRepositorio);
            var editFabricantesValidadorResultado = editFabricantesValidador.Validate(fabricantes);

            if (!editFabricantesValidadorResultado.IsValid)
            {
                throw new ValidationException(editFabricantesValidadorResultado.Errors);
            }

            this.fabricantesRepositorio.Update(fabricantes);
        }

        /// <summary>The delete fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        public void Delete(Fabricantes fabricantes)
        {
            //TODO: Crear validacion para que no deje borrar un fabricantes si ya fue asignado en la entidad Frabricas
            this.fabricantesRepositorio.Delete(fabricantes);
        }

        /// <summary>The list fabricantes.</summary>
        /// <param name="idFabricantes">The id fabricantes.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Fabricantes Get(int idFabricantes)
        {
            return this.fabricantesRepositorio.GetById(idFabricantes);
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
                return this.fabricantesRepositorio.GetFiltered(null, fabricantes => fabricantes.Pais).ToArray();
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
                return this.fabricantesRepositorio.GetFiltered(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}