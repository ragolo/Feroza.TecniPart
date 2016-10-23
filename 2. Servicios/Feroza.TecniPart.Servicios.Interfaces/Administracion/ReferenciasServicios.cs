// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenciasServicios.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   The referencias servicios.
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

    using Validadores.Administracion.Referencias;

    /// <summary>The referencias servicios.</summary>
    public class ReferenciasServicios : IReferenciasServicio
    {
        /// <summary>The referencias repositorio.</summary>
        private readonly IRepository<Referencias> referenciasRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="ReferenciasServicios"/> class.</summary>
        /// <param name="referenciasRepositorio">The referencias repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public ReferenciasServicios(IRepository<Referencias> referenciasRepositorio, IValidatorFactory validatorFactory)
        {
            this.referenciasRepositorio = referenciasRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        public void Add(Referencias referencias)
        {
            var addReferenciasValidador = new AddReferenciasValidador(this.referenciasRepositorio);
            var addReferenciasValidadorResultado = addReferenciasValidador.Validate(referencias);

            if (!addReferenciasValidadorResultado.IsValid)
            {
                throw new ValidationException(addReferenciasValidadorResultado.Errors);
            }

            this.referenciasRepositorio.Insert(referencias);
        }

        /// <summary>The edit referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Referencias referencias)
        {
            var editReferenciasValidador = new EditReferenciasValidador(this.referenciasRepositorio);
            var editReferenciasValidadorResultado = editReferenciasValidador.Validate(referencias);

            if (!editReferenciasValidadorResultado.IsValid)
            {
                throw new ValidationException(editReferenciasValidadorResultado.Errors);
            }

            this.referenciasRepositorio.Update(referencias);
        }

        /// <summary>The delete referencias.</summary>
        /// <param name="referencias">The referencias.</param>
        public void Delete(Referencias referencias)
        {
            //TODO: Crear validacion para que no deje borrar un referencias si ya fue asignado en la entidad Frabricas
            this.referenciasRepositorio.Delete(referencias);
        }

        /// <summary>The get.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Referencias"/>.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Referencias Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>The list referencias.</summary>
        /// <param name="idReferencias">The id referencias.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Referencias Get(string idReferencias)
        {
            return this.referenciasRepositorio.GetById(idReferencias);
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
                return this.referenciasRepositorio.GetFiltered(null, referencias => referencias.Aplicaciones, referencias => referencias.Sistemas, referencias => referencias.SubSistemas, referencias => referencias.Marcas).ToArray();
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
                return this.referenciasRepositorio.GetFiltered(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}