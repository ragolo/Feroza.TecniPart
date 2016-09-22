// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfProductosRepositorio.cs" company="Feroza">
//  Derechos de autor Feroza 
// </copyright>
// <summary>
//   The ef estado maestras repositorio.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Infraestructura.Data.Repositorios.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The ef estado maestras repositorio.
    /// </summary>
    public class EfProductosRepositorio : IProductosRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfProductosRepositorio"/> class.</summary>
        public EfProductosRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="productos">The estado Maestras.</param>
        /// <returns>The <see cref="Productos"/>.</returns>
        public Productos Crear(Productos productos)
        {
            var productosDataOriginal = this.context.Productos.FirstOrDefault(r => r.IdProductos == productos.IdProductos);

            if (productosDataOriginal == null || productos.IdProductos == 0)
            {
                productosDataOriginal = this.context.Productos.Create();
                productosDataOriginal.Descripcion = productos.Descripcion;
                productosDataOriginal.IdFabricantes = productos.IdFabricantes;
                productosDataOriginal.ImagenVehiculo = productos.ImagenVehiculo;
                productosDataOriginal.IdMarca = productos.IdMarca;
                productosDataOriginal.Ango = productos.Ango;
                productosDataOriginal.Comentario = productos.Comentario;


                this.context.Productos.Add(productosDataOriginal);
                this.context.SaveChanges();
                productos.IdProductos = productosDataOriginal.IdProductos;
                return productos;
            }

            throw new Exception($"El estado maestra ya existe {productos.IdProductos}");
        }

        /// <summary>The editar.</summary>
        /// <param name="productos">The estado maestras.</param>
        /// <returns>The <see cref="Productos"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Productos Editar(Productos productos)
        {
            var productosDataOriginal = this.context.Productos.FirstOrDefault(r => r.IdProductos == productos.IdProductos);


            if (productosDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var productosDataMap = new ProductosData
                {

                    IdProductos = productos.IdProductos,
                    Descripcion = productos.Descripcion,
                    ImagenVehiculo = productos.ImagenVehiculo,
                    IdFabricantes = productos.IdFabricantes,
                    IdMarca = productos.IdMarca,
                    Ango = productos.Ango,
                    Comentario = productos.Comentario
                };
                productosDataMap.IdProductos = productosDataOriginal.IdProductos;
                this.context.Entry(productosDataOriginal).CurrentValues.SetValues(productosDataMap);
                this.context.SaveChanges();
                return productos;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {productos.IdProductos}");
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idProductos">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idProductos)
        {
            var productosToDelete = this.context.Productos.FirstOrDefault(r => r.IdProductos.Equals(idProductos));
            this.context.Productos.Remove(productosToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idProductos">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Productos> ListarProductos(int idProductos)
        {
            return this.context.Productos.Where(r => r.IdProductos == idProductos).Select(s => new Productos
            {
                IdProductos = s.IdProductos,
                Descripcion = s.Descripcion,
                ImagenVehiculo = s.ImagenVehiculo,
                IdFabricantes = s.IdFabricantes,
                IdMarca = s.IdMarca,
                Ango = s.Ango,
                Comentario = s.Comentario
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Productos/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Productos> ListarProductoses()
        {
            return this.context.Productos.Select(s => new Productos
            {
                IdProductos = s.IdProductos,
                Descripcion = s.Descripcion,
                ImagenVehiculo = s.ImagenVehiculo,
                IdFabricantes = s.IdFabricantes,
                IdMarca = s.IdMarca,
                Ango = s.Ango,
                Comentario = s.Comentario
            });
        }
    }
}