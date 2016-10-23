// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculosServicios.cs" company="Feroza">
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

    using Validadores.Administracion.Vehiculos;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class VehiculosServicios : IVehiculosServicio
    {
        /// <summary>The pais repositorio.</summary>
        private readonly IRepository<Vehiculos> paisRepositorio;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="VehiculosServicios"/> class.</summary>
        /// <param name="paisRepositorio">The pais repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public VehiculosServicios(IRepository<Vehiculos> paisRepositorio, IValidatorFactory validatorFactory)
        {
            this.paisRepositorio = paisRepositorio;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Add(Vehiculos pais)
        {
            var addVehiculosValidador = new AddVehiculosValidador(this.paisRepositorio);
            var addVehiculosValidadorResultado = addVehiculosValidador.Validate(pais);

            if (!addVehiculosValidadorResultado.IsValid)
            {
                throw new ValidationException(addVehiculosValidadorResultado.Errors);
            }

            this.paisRepositorio.Insert(pais);
        }

        /// <summary>The edit pais.</summary>
        /// <param name="pais">The pais.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Vehiculos pais)
        {
            var editVehiculosValidador = new EditVehiculosValidador(this.paisRepositorio);
            var editVehiculosValidadorResultado = editVehiculosValidador.Validate(pais);

            if (!editVehiculosValidadorResultado.IsValid)
            {
                throw new ValidationException(editVehiculosValidadorResultado.Errors);
            }

            this.paisRepositorio.Update(pais);
        }

        /// <summary>The delete pais.</summary>
        /// <param name="pais">The pais.</param>
        public void Delete(Vehiculos pais)
        {
            //TODO: Crear validacion para que no deje borrar un pais si ya fue asignado en la entidad Frabricas
            this.paisRepositorio.Delete(pais);
        }

        /// <summary>The list pais.</summary>
        /// <param name="idVehiculos">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Vehiculos Get(int idVehiculos)
        {
            return this.paisRepositorio.GetById(idVehiculos);
        }

        /// <summary>The list pais.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Vehiculos> List()
        {
            try
            {
                return this.paisRepositorio.GetFiltered(null, vehiculos => vehiculos.Fabricantes, vehiculos => vehiculos.Marcas).ToArray();
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
        public IList<Vehiculos> ListFiltered(Expression<Func<Vehiculos, bool>> filter)
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