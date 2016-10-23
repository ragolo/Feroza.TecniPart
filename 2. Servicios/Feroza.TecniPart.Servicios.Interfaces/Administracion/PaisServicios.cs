// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaisServicios.cs" company="Feroza">
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

    using Validadores.Administracion.Pais;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class PaisServicios : IPaisServicio
    {
        /// <summary>The pais repositorio.</summary>
        private readonly IRepository<Pais> paisRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="PaisServicios"/> class.</summary>
        /// <param name="paisRepositorio">The pais repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public PaisServicios(IRepository<Pais> paisRepositorio, IValidatorFactory validatorFactory)
        {
            this.paisRepositorio = paisRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Add(Pais pais)
        {
            var addPaisValidador = new AddPaisValidador(this.paisRepositorio);
            var addPaisValidadorResultado = addPaisValidador.Validate(pais);

            if (!addPaisValidadorResultado.IsValid)
            {
                throw new ValidationException(addPaisValidadorResultado.Errors);
            }

            this.paisRepositorio.Insert(pais);
        }

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Pais pais)
        {
            var editPaisValidador = new EditPaisValidador(this.paisRepositorio);
            var editPaisValidadorResultado = editPaisValidador.Validate(pais);

            if (!editPaisValidadorResultado.IsValid)
            {
                throw new ValidationException(editPaisValidadorResultado.Errors);
            }

            this.paisRepositorio.Update(pais);
        }

        /// <summary>The delete pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Delete(Pais pais)
        {
            //TODO: Crear validacion para que no deje borrar un pais si ya fue asignado en la entidad Frabricas
            this.paisRepositorio.Delete(pais);
        }

        /// <summary>The list pais.</summary>
        /// <param name="idPais">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Pais Get(int idPais)
        {
            return this.paisRepositorio.GetById(idPais);
        }

        /// <summary>The list pais.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Pais> List()
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
        public IList<Pais> ListFiltered(Expression<Func<Pais, bool>> filter)
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