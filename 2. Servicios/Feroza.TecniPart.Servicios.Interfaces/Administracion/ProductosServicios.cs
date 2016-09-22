// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductosServicios.cs" company="Feroza">
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
    public class ProductosServicios : IProductosServicio
    {
        /// <summary>
        /// The estado maestras repositorio.
        /// </summary>
        private readonly IProductosRespositorio marcasRepositorio;

        /// <summary>Initializes a new instance of the <see cref="ProductosServicios"/> class.</summary>
        /// <param name="marcasRepositorio">The marcas repositorio.</param>
        public ProductosServicios(IProductosRespositorio marcasRepositorio)
        {
            this.marcasRepositorio = marcasRepositorio;
        }

        /// <summary>The add marcas.</summary>
        /// <param name="marcas">The marcas.</param>
        public Productos AddProductos(Productos marcas)
        {
            return this.marcasRepositorio.Crear(marcas);
        }

        public Productos EditProductos(Productos marcas)
        {
            return this.marcasRepositorio.Editar(marcas);
        }

        /// <summary>The delete marcas.</summary>
        /// <param name="idProductos">The id marcas.</param>
        public void DeleteProductos(int idProductos)
        {
            this.marcasRepositorio.Eliminar(idProductos);
        }

        /// <summary>The list marcas.</summary>
        /// <param name="idProductos">The id marcas.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Productos> ListProductos(int idProductos)
        {
            return this.marcasRepositorio.ListarProductos(idProductos);
        }

        /// <summary>The list marcas.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Productos> ListProductos()
        {
            return this.marcasRepositorio.ListarProductoses();
        }
    }
}