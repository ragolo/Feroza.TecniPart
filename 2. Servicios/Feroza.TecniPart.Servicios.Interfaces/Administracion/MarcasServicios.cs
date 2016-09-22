// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcasServicios.cs" company="Feroza">
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
    public class MarcasServicios : IMarcasServicio
    {
        /// <summary>
        /// The estado maestras repositorio.
        /// </summary>
        private readonly IMarcasRespositorio marcasRepositorio;

        /// <summary>Initializes a new instance of the <see cref="MarcasServicios"/> class.</summary>
        /// <param name="marcasRepositorio">The marcas repositorio.</param>
        public MarcasServicios(IMarcasRespositorio marcasRepositorio)
        {
            this.marcasRepositorio = marcasRepositorio;
        }

        /// <summary>The add marcas.</summary>
        /// <param name="marcas">The marcas.</param>
        public Marcas AddMarcas(Marcas marcas)
        {
            return this.marcasRepositorio.Crear(marcas);
        }

        public Marcas EditMarcas(Marcas marcas)
        {
            return this.marcasRepositorio.Editar(marcas);
        }

        /// <summary>The delete marcas.</summary>
        /// <param name="idMarcas">The id marcas.</param>
        public void DeleteMarcas(int idMarcas)
        {
            this.marcasRepositorio.Eliminar(idMarcas);
        }

        /// <summary>The list marcas.</summary>
        /// <param name="idMarcas">The id marcas.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Marcas> ListMarcas(int idMarcas)
        {
            return this.marcasRepositorio.ListarMarcas(idMarcas);
        }

        /// <summary>The list marcas.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Marcas> ListMarcas()
        {
            return this.marcasRepositorio.ListarMarcases();
        }
    }
}