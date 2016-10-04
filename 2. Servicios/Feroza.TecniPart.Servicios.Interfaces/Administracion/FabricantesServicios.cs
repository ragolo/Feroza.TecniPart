// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FabricantesServicios.cs" company="Feroza">
//   Derechos de autor Feroza
// </copyright>
// <summary>
//   Defines the EstadoMaestrasServicios type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Administracion
{
    using System.Collections.Generic;
    using System.Linq;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    using Extensions;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class FabricantesServicios : IFabricantesServicio
    {
        /// <summary>
        /// The estado maestras repositorio.
        /// </summary>
        private readonly IFabricantesRespositorio fabricantesRepositorio;

        /// <summary>Initializes a new instance of the <see cref="FabricantesServicios"/> class.</summary>
        /// <param name="fabricantesRepositorio">The fabricantes repositorio.</param>
        public FabricantesServicios(IFabricantesRespositorio fabricantesRepositorio)
        {
            this.fabricantesRepositorio = fabricantesRepositorio;
        }

        /// <summary>The add fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        public Fabricantes AddFabricantes(Fabricantes fabricantes)
        {
            return this.fabricantesRepositorio.Crear(fabricantes);
        }

        /// <summary>The edit fabricantes.</summary>
        /// <param name="fabricantes">The fabricantes.</param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        public Fabricantes EditFabricantes(Fabricantes fabricantes)
        {
            return this.fabricantesRepositorio.Editar(fabricantes);
        }

        /// <summary>The delete fabricantes.</summary>
        /// <param name="idFabricantes">The id fabricantes.</param>
        public void DeleteFabricantes(int idFabricantes)
        {
            this.fabricantesRepositorio.Eliminar(idFabricantes);
        }

        /// <summary>The list fabricantes.</summary>
        /// <param name="idFabricantes">The id fabricantes.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Fabricantes> ListFabricantes(int idFabricantes)
        {
            var fabricantes = this.fabricantesRepositorio.ListarFabricantes(idFabricantes);

            return fabricantes;
        }

        /// <summary>The list fabricantes.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Fabricantes> ListFabricantes()
        {
            var fabricantes = this.fabricantesRepositorio.ListarFabricanteses();

            return fabricantes;
        }
    }
}