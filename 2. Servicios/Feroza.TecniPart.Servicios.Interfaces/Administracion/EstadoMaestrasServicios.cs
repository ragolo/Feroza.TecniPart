﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EstadoMaestrasServicios.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the EstadoMaestrasServicios type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class EstadoMaestrasServicios : IEstadoMaestrasServicios
    {
        /// <summary>
        /// The estado maestras repositorio.
        /// </summary>
        private readonly IEstadoMaestrasRespositorio estadoMaestrasRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="EstadoMaestrasServicios"/> class.
        /// </summary>
        /// <param name="estadoMaestrasRepository">
        /// The estado maestras repository.
        /// </param>
        public EstadoMaestrasServicios(IEstadoMaestrasRespositorio estadoMaestrasRepository)
        {
            this.estadoMaestrasRepositorio = estadoMaestrasRepository;
        }

        /// <summary>
        /// The add estado maestras.
        /// </summary>
        /// <param name="estadoMaestras">
        /// The estado maestras.
        /// </param>
        public void AddEstadoMaestras(EstadoMaestras estadoMaestras)
        {
            this.estadoMaestrasRepositorio.Crear(estadoMaestras.Desripcion);
        }

        /// <summary>
        /// The delete estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">
        /// The id estado maestras.
        /// </param>
        public void DeleteEstadoMaestras(int idEstadoMaestras)
        {
            this.estadoMaestrasRepositorio.Eliminar(idEstadoMaestras);
        }

        /// <summary>
        /// The list estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<EstadoMaestras> ListEstadoMaestras(int idEstadoMaestras)
        {
            return this.estadoMaestrasRepositorio.ListarEstadoMaestras(idEstadoMaestras);
        }
    }
}