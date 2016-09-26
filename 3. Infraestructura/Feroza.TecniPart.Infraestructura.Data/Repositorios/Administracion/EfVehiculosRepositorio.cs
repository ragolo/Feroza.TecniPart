// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfVehiculosRepositorio.cs" company="Feroza">
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
    public class EfVehiculosRepositorio : IVehiculosRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfVehiculosRepositorio"/> class.</summary>
        public EfVehiculosRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="vehiculos">The estado Maestras.</param>
        /// <returns>The <see cref="Vehiculos"/>.</returns>
        public Vehiculos Crear(Vehiculos vehiculos)
        {
            var vehiculosDataOriginal = this.context.Vehiculos.FirstOrDefault(r => r.IdVehiculos == vehiculos.IdVehiculos);

            if (vehiculosDataOriginal == null || vehiculos.IdVehiculos == 0)
            {
                vehiculosDataOriginal = this.context.Vehiculos.Create();
                vehiculosDataOriginal.Descripcion = vehiculos.Descripcion;
                vehiculosDataOriginal.IdFabricantes = vehiculos.IdFabricantes;
                vehiculosDataOriginal.ImagenVehiculo = vehiculos.ImagenVehiculo;
                vehiculosDataOriginal.IdMarca = vehiculos.IdMarca;
                vehiculosDataOriginal.Ango = vehiculos.Ango;
                vehiculosDataOriginal.Comentario = vehiculos.Comentario;


                this.context.Vehiculos.Add(vehiculosDataOriginal);
                this.context.SaveChanges();
                vehiculos.IdVehiculos = vehiculosDataOriginal.IdVehiculos;
                vehiculos.IdFabricantes = vehiculosDataOriginal.IdFabricantes;
                vehiculos.Marcas = new Marcas { Descripcion = vehiculosDataOriginal.Marcas.Descripcion, IdMarcas = vehiculosDataOriginal.Marcas.IdMarcas };
                vehiculos.Fabricantes = new Fabricantes() { Descripcion = vehiculosDataOriginal.Fabricantes.Descripcion, IdFabricantes = vehiculosDataOriginal.Fabricantes.IdFabricantes };

                return vehiculos;
            }

            throw new Exception($"El estado maestra ya existe {vehiculos.IdVehiculos}");
        }

        /// <summary>The editar.</summary>
        /// <param name="vehiculos">The estado maestras.</param>
        /// <returns>The <see cref="Vehiculos"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Vehiculos Editar(Vehiculos vehiculos)
        {
            var vehiculosDataOriginal = this.context.Vehiculos.FirstOrDefault(r => r.IdVehiculos == vehiculos.IdVehiculos);


            if (vehiculosDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var vehiculosDataMap = new VehiculosData
                {

                    IdVehiculos = vehiculos.IdVehiculos,
                    Descripcion = vehiculos.Descripcion,
                    ImagenVehiculo = vehiculos.ImagenVehiculo,
                    IdFabricantes = vehiculos.IdFabricantes,
                    IdMarca = vehiculos.IdMarca,
                    Ango = vehiculos.Ango,
                    Comentario = vehiculos.Comentario
                };
                vehiculosDataMap.IdVehiculos = vehiculosDataOriginal.IdVehiculos;
                this.context.Entry(vehiculosDataOriginal).CurrentValues.SetValues(vehiculosDataMap);
                this.context.SaveChanges();

                vehiculos.IdFabricantes = vehiculosDataOriginal.IdFabricantes;
                vehiculos.Marcas = new Marcas { Descripcion = vehiculosDataOriginal.Marcas.Descripcion, IdMarcas = vehiculosDataOriginal.Marcas.IdMarcas };
                vehiculos.Fabricantes = new Fabricantes() { Descripcion = vehiculosDataOriginal.Fabricantes.Descripcion, IdFabricantes = vehiculosDataOriginal.Fabricantes.IdFabricantes };

                return vehiculos;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {vehiculos.IdVehiculos}");
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idVehiculos">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idVehiculos)
        {
            var vehiculosToDelete = this.context.Vehiculos.FirstOrDefault(r => r.IdVehiculos.Equals(idVehiculos));
            this.context.Vehiculos.Remove(vehiculosToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idVehiculos">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Vehiculos> ListarVehiculos(int idVehiculos)
        {
            return this.context.Vehiculos.Where(r => r.IdVehiculos == idVehiculos).Select(s => new Vehiculos
            {
                IdVehiculos = s.IdVehiculos,
                Descripcion = s.Descripcion,
                ImagenVehiculo = s.ImagenVehiculo,
                IdFabricantes = s.IdFabricantes,
                IdMarca = s.IdMarca,
                Ango = s.Ango,
                Comentario = s.Comentario,
                Fabricantes = new Fabricantes
                {
                    Descripcion = s.Fabricantes.Descripcion,
                    IdFabricantes = s.Fabricantes.IdFabricantes
                },
                Marcas = new Marcas
                {
                    Descripcion = s.Marcas.Descripcion,
                    IdMarcas = s.Marcas.IdMarcas
                }
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Vehiculos/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Vehiculos> ListarVehiculoses()
        {
            return this.context.Vehiculos.Select(s => new Vehiculos
            {
                IdVehiculos = s.IdVehiculos,
                Descripcion = s.Descripcion,
                ImagenVehiculo = s.ImagenVehiculo,
                IdFabricantes = s.IdFabricantes,
                IdMarca = s.IdMarca,
                Ango = s.Ango,
                Comentario = s.Comentario,
                Fabricantes = new Fabricantes
                                  {
                                      Descripcion = s.Fabricantes.Descripcion,
                                      IdFabricantes = s.Fabricantes.IdFabricantes
                                  },
                Marcas = new Marcas
                             {
                                 Descripcion = s.Marcas.Descripcion,
                                 IdMarcas = s.Marcas.IdMarcas
                             }
            });
        }
    }
}