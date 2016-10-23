// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SistemasServicios.cs" company="Feroza">
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

    using Feroza.TecniPart.Dominio.Interfaces.Repositorio;
    using Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Sistemas;

    using FluentValidation;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class SistemasServicios : ISistemasServicio
    {
        /// <summary>The pais repositorio.</summary>
        private readonly IRepository<Sistemas> paisRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="SistemasServicios"/> class.</summary>
        /// <param name="paisRepositorio">The pais repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public SistemasServicios(IRepository<Sistemas> paisRepositorio, IValidatorFactory validatorFactory)
        {
            this.paisRepositorio = paisRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Add(Sistemas pais)
        {
            var addSistemasValidador = new AddSistemasValidador(this.paisRepositorio);
            var addSistemasValidadorResultado = addSistemasValidador.Validate(pais);

            if (!addSistemasValidadorResultado.IsValid)
            {
                throw new ValidationException(addSistemasValidadorResultado.Errors);
            }

            this.paisRepositorio.Insert(pais);
        }

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Sistemas pais)
        {
            var editSistemasValidador = new EditSistemasValidador(this.paisRepositorio);
            var editSistemasValidadorResultado = editSistemasValidador.Validate(pais);

            if (!editSistemasValidadorResultado.IsValid)
            {
                throw new ValidationException(editSistemasValidadorResultado.Errors);
            }

            this.paisRepositorio.Update(pais);
        }

        /// <summary>The delete pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Delete(Sistemas pais)
        {
            //TODO: Crear validacion para que no deje borrar un pais si ya fue asignado en la entidad Frabricas
            this.paisRepositorio.Delete(pais);
        }

        /// <summary>The list pais.</summary>
        /// <param name="idSistemas">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Sistemas Get(int idSistemas)
        {
            return this.paisRepositorio.GetById(idSistemas);
        }

        /// <summary>The list pais.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Sistemas> List()
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
        public IList<Sistemas> ListFiltered(Expression<Func<Sistemas, bool>> filter)
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