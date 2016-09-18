// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EstadoMaestrasServicios.cs" company="Feroza">
//   Derechos de autor Feroza
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
    public class EstadoMaestrasServicios : IEstadoMaestrasServicio
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

        /// <summary>The add estado maestras.</summary>
        /// <param name="estadoMaestras">The estado maestras.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        public EstadoMaestras AddEstadoMaestras(EstadoMaestras estadoMaestras)
        {
            return this.estadoMaestrasRepositorio.Crear(estadoMaestras);
        }

        /// <summary>The edit estado maestras.</summary>
        /// <param name="estadoMaestras">The estado maestras.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        public EstadoMaestras EditEstadoMaestras(EstadoMaestras estadoMaestras)
        {
            return this.estadoMaestrasRepositorio.Editar(estadoMaestras);

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
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        public IEnumerable<EstadoMaestras> ListEstadoMaestras(int idEstadoMaestras)
        {
            return this.estadoMaestrasRepositorio.ListarEstadoMaestras(idEstadoMaestras);
        }

        /// <summary>The list estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<EstadoMaestras> ListEstadoMaestras()
        {
            return this.estadoMaestrasRepositorio.ListarEstadoMaestras();
        }
    }
}