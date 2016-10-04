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
    using System.Collections.Generic;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class SubSistemasServicios : ISubSistemasServicio
    {
        /// <summary>The subSistemas repositorio.</summary>
        private readonly ISubSistemasRespositorio subSistemasRepositorio;

        /// <summary>Initializes a new instance of the <see cref="SubSistemasServicios"/> class.</summary>
        /// <param name="subSistemasRepositorio">The subSistemas repositorio.</param>
        public SubSistemasServicios(ISubSistemasRespositorio subSistemasRepositorio)
        {
            this.subSistemasRepositorio = subSistemasRepositorio;
        }

        /// <summary>The add subSistemas.</summary>
        /// <param name="subSistemas">The subSistemas.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        public SubSistemas AddSubSistemas(SubSistemas subSistemas)
        {
            return this.subSistemasRepositorio.Crear(subSistemas);
        }

        /// <summary>The edit subSistemas.</summary>
        /// <param name="subSistemas">The subSistemas.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        public SubSistemas EditSubSistemas(SubSistemas subSistemas)
        {
            return this.subSistemasRepositorio.Editar(subSistemas);
        }

        /// <summary>The delete subSistemas.</summary>
        /// <param name="idSubSistemas">The id subSistemas.</param>
        public void DeleteSubSistemas(int idSubSistemas)
        {
            this.subSistemasRepositorio.Eliminar(idSubSistemas);
        }

        /// <summary>The list subSistemas.</summary>
        /// <param name="idSubSistemas">The id subSistemas.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<SubSistemas> ListSubSistemas(int idSubSistemas)
        {
            return this.subSistemasRepositorio.ListarSubSistemas(idSubSistemas);
        }

        /// <summary>The list subSistemas.</summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<SubSistemas> ListSubSistemas()
        {
            return this.subSistemasRepositorio.ListarSubSistemases();
        }
    }
}