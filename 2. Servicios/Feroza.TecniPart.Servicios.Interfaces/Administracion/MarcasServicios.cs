// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasServicios.cs" company="Feroza">
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

    using Validadores.Administracion.Marcas;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class MarcasServicios : IMarcasServicio
    {
        /// <summary>The pais repositorio.</summary>
        private readonly IRepository<Marcas> paisRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="MarcasServicios"/> class.</summary>
        /// <param name="paisRepositorio">The pais repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public MarcasServicios(IRepository<Marcas> paisRepositorio, IValidatorFactory validatorFactory)
        {
            this.paisRepositorio = paisRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Add(Marcas pais)
        {
            var addMarcasValidador = new AddMarcasValidador(this.paisRepositorio);
            var addMarcasValidadorResultado = addMarcasValidador.Validate(pais);

            if (!addMarcasValidadorResultado.IsValid)
            {
                throw new ValidationException(addMarcasValidadorResultado.Errors);
            }

            this.paisRepositorio.Insert(pais);
        }

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Marcas pais)
        {
            var editMarcasValidador = new EditMarcasValidador(this.paisRepositorio);
            var editMarcasValidadorResultado = editMarcasValidador.Validate(pais);

            if (!editMarcasValidadorResultado.IsValid)
            {
                throw new ValidationException(editMarcasValidadorResultado.Errors);
            }

            this.paisRepositorio.Update(pais);
        }

        /// <summary>The delete pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Delete(Marcas pais)
        {
            //TODO: Crear validacion para que no deje borrar un pais si ya fue asignado en la entidad Frabricas
            this.paisRepositorio.Delete(pais);
        }

        /// <summary>The list pais.</summary>
        /// <param name="idMarcas">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Marcas Get(int idMarcas)
        {
            return this.paisRepositorio.GetById(idMarcas);
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
                return this.paisRepositorio.GetFiltered(null).ToArray();
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
                return this.paisRepositorio.GetFiltered(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}