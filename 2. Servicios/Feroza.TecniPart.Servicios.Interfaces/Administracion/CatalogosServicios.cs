// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatalogosServicios.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   The estado maestras servicios.
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

    using Validadores.Administracion.Catalogos;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class CatalogosServicios : ICatalogosServicio
    {
        /// <summary>The pais repositorio.</summary>
        private readonly IRepository<Catalogos> paisRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="CatalogosServicios"/> class.</summary>
        /// <param name="paisRepositorio">The pais repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public CatalogosServicios(IRepository<Catalogos> paisRepositorio, IValidatorFactory validatorFactory)
        {
            this.paisRepositorio = paisRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Add(Catalogos pais)
        {
            var addCatalogosValidador = new AddCatalogosValidador(this.paisRepositorio);
            var addCatalogosValidadorResultado = addCatalogosValidador.Validate(pais);

            if (!addCatalogosValidadorResultado.IsValid)
            {
                throw new ValidationException(addCatalogosValidadorResultado.Errors);
            }

            this.paisRepositorio.Insert(pais);
        }

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Catalogos pais)
        {
            var editCatalogosValidador = new EditCatalogosValidador(this.paisRepositorio);
            var editCatalogosValidadorResultado = editCatalogosValidador.Validate(pais);

            if (!editCatalogosValidadorResultado.IsValid)
            {
                throw new ValidationException(editCatalogosValidadorResultado.Errors);
            }

            this.paisRepositorio.Update(pais);
        }

        /// <summary>The delete pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Delete(Catalogos pais)
        {
            //TODO: Crear validacion para que no deje borrar un pais si ya fue asignado en la entidad Frabricas
            this.paisRepositorio.Delete(pais);
        }

        /// <summary>The list pais.</summary>
        /// <param name="idCatalogos">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Catalogos Get(int idCatalogos)
        {
            return this.paisRepositorio.GetById(idCatalogos);
        }

        /// <summary>The list pais.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Catalogos> List()
        {
            try
            {
                return this.paisRepositorio.GetFiltered(null, catalogos => catalogos.Vehiculos, catalogos => catalogos.Sistemas, catalogos => catalogos.SubSistemas).ToArray();
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
        public IList<Catalogos> ListFiltered(Expression<Func<Catalogos, bool>> filter)
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