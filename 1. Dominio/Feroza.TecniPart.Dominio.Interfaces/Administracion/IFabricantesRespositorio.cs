// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFabricantesRespositorio.cs" company="Feroza">
//   
// </copyright>
// <summary>
//   Defines the IFabricantesRespositorio type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Dominio.Interfaces.Administracion
{
    using System.Collections.Generic;

    using Entidades.Modelos;

    /// <summary>
    /// The FabricantesRespositorio interface.
    /// </summary>
    public interface IFabricantesRespositorio
    {
        /// <summary>Crears the specified descripcion.</summary>
        /// <param name="pais"></param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        Fabricantes Crear(Fabricantes pais);

        /// <summary>The editar.</summary>
        /// <param name="pais"></param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        Fabricantes Editar(Fabricantes pais);

        /// <summary>
        /// Eliminars the specified identifier estado maestras.
        /// </summary>
        /// <param name="idFabricantes">The identifier estado maestras.</param>
        void Eliminar(int idFabricantes);

        /// <summary>The listar estado maestras.</summary>
        /// <param name="idFabricantes">The id estado maestras.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Fabricantes/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Fabricantes> ListarFabricantes(int idFabricantes);

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Fabricantes/></cref>
        ///     </see>
        /// .</returns>
        IEnumerable<Fabricantes> ListarFabricanteses();
    }
}
