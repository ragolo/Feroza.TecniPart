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
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class PaisServicios : IPaisServicio
    {
        /// <summary>
        /// The estado maestras repositorio.
        /// </summary>
        private readonly IPaisRespositorio paisRepositorio;

        /// <summary>Initializes a new instance of the <see cref="PaisServicios"/> class.</summary>
        /// <param name="paisRepositorio">The pais repositorio.</param>
        public PaisServicios(IPaisRespositorio paisRepositorio)
        {
            this.paisRepositorio = paisRepositorio;
        }

        /// <summary>The add pais.</summary>
        /// <param name="pais">The pais.</param>
        public Pais AddPais(Pais pais)
        {
            return this.paisRepositorio.Crear(pais);
        }

        public Pais EditPais(Pais pais)
        {
            return this.paisRepositorio.Editar(pais);
        }

        /// <summary>The delete pais.</summary>
        /// <param name="idPais">The id pais.</param>
        public void DeletePais(int idPais)
        {
            this.paisRepositorio.Eliminar(idPais);
        }

        /// <summary>The list pais.</summary>
        /// <param name="idPais">The id pais.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Pais> ListPais(int idPais)
        {
            return this.paisRepositorio.ListarPais(idPais);
        }

        /// <summary>The list pais.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Pais> ListPais()
        {
            return this.paisRepositorio.ListarPaises();
        }
    }
}