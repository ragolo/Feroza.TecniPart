// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubSistemasServicios.cs" company="Feroza">
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

    using Validadores.Administracion.SubSistemas;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class SubSistemasServicios : ISubSistemasServicio
    {
        /// <summary>The subSistemas repositorio.</summary>
        private readonly IRepository<SubSistemas> subSistemasRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="SubSistemasServicios"/> class.</summary>
        /// <param name="subSistemasRepositorio">The subSistemas repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public SubSistemasServicios(IRepository<SubSistemas> subSistemasRepositorio, IValidatorFactory validatorFactory)
        {
            this.subSistemasRepositorio = subSistemasRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add subSistemas.</summary>
        /// <param name="subSistemas">The subSistemas.</param>
        public void Add(SubSistemas subSistemas)
        {
            var addSubSistemasValidador = new AddSubSistemasValidador(this.subSistemasRepositorio);
            var addSubSistemasValidadorResultado = addSubSistemasValidador.Validate(subSistemas);

            if (!addSubSistemasValidadorResultado.IsValid)
            {
                throw new ValidationException(addSubSistemasValidadorResultado.Errors);
            }

            this.subSistemasRepositorio.Insert(subSistemas);
        }

        /// <summary>The edit subSistemas.</summary>
        /// <param name="subSistemas">The subSistemas.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(SubSistemas subSistemas)
        {
            var editSubSistemasValidador = new EditSubSistemasValidador(this.subSistemasRepositorio);
            var editSubSistemasValidadorResultado = editSubSistemasValidador.Validate(subSistemas);

            if (!editSubSistemasValidadorResultado.IsValid)
            {
                throw new ValidationException(editSubSistemasValidadorResultado.Errors);
            }

            this.subSistemasRepositorio.Update(subSistemas);
        }

        /// <summary>The delete subSistemas.</summary>
        /// <param name="subSistemas">The subSistemas.</param>
        public void Delete(SubSistemas subSistemas)
        {
            //TODO: Crear validacion para que no deje borrar un subSistemas si ya fue asignado en la entidad Frabricas
            this.subSistemasRepositorio.Delete(subSistemas);
        }

        /// <summary>The list subSistemas.</summary>
        /// <param name="idSubSistemas">The id subSistemas.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public SubSistemas Get(int idSubSistemas)
        {
            return this.subSistemasRepositorio.GetById(idSubSistemas);
        }

        /// <summary>The list subSistemas.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<SubSistemas> List()
        {
            try
            {
                return this.subSistemasRepositorio.GetFiltered(null, subSistemas => subSistemas.Sistemas).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list subSistemas filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<SubSistemas> ListFiltered(Expression<Func<SubSistemas, bool>> filter)
        {
            try
            {
                return this.subSistemasRepositorio.GetFiltered(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}