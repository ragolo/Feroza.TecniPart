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
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class SistemasServicios : ISistemasServicio
    {
        /// <summary>The sistemas repositorio.</summary>
        private readonly ISistemasRespositorio sistemasRepositorio;

        /// <summary>Initializes a new instance of the <see cref="SistemasServicios"/> class.</summary>
        /// <param name="sistemasRepositorio">The sistemas repositorio.</param>
        public SistemasServicios(ISistemasRespositorio sistemasRepositorio)
        {
            this.sistemasRepositorio = sistemasRepositorio;
        }

        /// <summary>The add sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        public Sistemas AddSistemas(Sistemas sistemas)
        {
            return this.sistemasRepositorio.Crear(sistemas);
        }

        /// <summary>The edit sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        public Sistemas EditSistemas(Sistemas sistemas)
        {
            return this.sistemasRepositorio.Editar(sistemas);
        }

        /// <summary>The delete sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        public void DeleteSistemas(int idSistemas)
        {
            this.sistemasRepositorio.Eliminar(idSistemas);
        }

        /// <summary>The list sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<Sistemas> ListSistemas(int idSistemas)
        {
            return this.sistemasRepositorio.ListarSistemas(idSistemas);
        }

        /// <summary>The list sistemas.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<Sistemas> ListSistemas()
        {
            return this.sistemasRepositorio.ListarSistemases();
        }
    }
}