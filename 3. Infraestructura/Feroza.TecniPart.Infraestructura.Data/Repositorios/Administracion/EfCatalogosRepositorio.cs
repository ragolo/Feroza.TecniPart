// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfCatalogosRepositorio.cs" company="Feroza">
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
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using Data;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The ef estado maestras repositorio.
    /// </summary>
    public class EfCatalogosRepositorio : ICatalogosRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfCatalogosRepositorio"/> class.</summary>
        public EfCatalogosRepositorio()
        {
            this.context = new TecniPartEntities();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CatalogosData, Catalogos>().MaxDepth(1);
                cfg.CreateMap<Catalogos, CatalogosData>().MaxDepth(1);
                cfg.CreateMap<SistemasData, Sistemas>();
                cfg.CreateMap<Sistemas, SistemasData>();
                cfg.CreateMap<SubSistemasData, SubSistemas>();
                cfg.CreateMap<SubSistemas, SubSistemasData>();
                cfg.CreateMap<VehiculosData, Vehiculos>();
                cfg.CreateMap<Vehiculos, VehiculosData>();
                cfg.CreateMap<MarcasData, Marcas>();
                cfg.CreateMap<Marcas, MarcasData>();
                cfg.CreateMap<FabricantesData, Fabricantes>();
                cfg.CreateMap<Fabricantes, FabricantesData>();
            });
        }

        /// <summary>The crear.</summary>
        /// <param name="catalogos">The estado Maestras.</param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        public Catalogos Crear(Catalogos catalogos)
        {
            var catalogosDataOriginal = this.context.Catalogos
                   .Include("Sistemas")
                                 .Include("SubSistemas")
                                 .Include("Vehiculos")
                .FirstOrDefault(r => r.IdCatalogos == catalogos.IdCatalogos);

            if (catalogosDataOriginal == null || catalogos.IdCatalogos == 0)
            {
                catalogosDataOriginal = Mapper.Map<Catalogos, CatalogosData>(catalogos);
                this.context.Catalogos.Add(catalogosDataOriginal);
                this.context.SaveChanges();
                catalogos = Mapper.Map<CatalogosData, Catalogos>(catalogosDataOriginal);
                return catalogos;
            }

            throw new Exception($"El Catalogo ya existe {catalogos.IdCatalogos}");
        }

        /// <summary>The editar.</summary>
        /// <param name="catalogos">The estado maestras.</param>
        /// <returns>The <see cref="Catalogos"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Catalogos Editar(Catalogos catalogos)
        {
            var catalogosDataOriginal = this.context.Catalogos.FirstOrDefault(r => r.IdCatalogos == catalogos.IdCatalogos);


            if (catalogosDataOriginal != null)
            {
                var catalogosDataMap = new CatalogosData()
                {
                    IdVehiculos = catalogos.IdVehiculos,
                    IdCatalogos = catalogos.IdCatalogos,
                    IdSistemas = catalogos.IdSistemas,
                    IdSubSistemas = catalogos.IdSubSistemas,
                    ImagenCatalogo = catalogos.ImagenCatalogo
                };

                this.context.Entry(catalogosDataOriginal).CurrentValues.SetValues(catalogosDataMap);
                this.context.SaveChanges();
                return catalogos;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {catalogos.IdCatalogos}");
        }

        /// <summary>The eliminar.</summary>
        /// <param name="id">The id.</param>
        public void Eliminar(int id)
        {
            var catalogosToDelete = this.context.Catalogos.FirstOrDefault(r => r.IdCatalogos.Equals(id));
            this.context.Catalogos.Remove(catalogosToDelete);
            this.context.SaveChanges();
        }

        /// <summary>The listar estado maestras.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<Catalogos> ListarCatalogos(int id)
        {
            var catalogosData = (from catalogo in this.context.Catalogos
                                 .Include("Sistemas")
                                 .Include("SubSistemas")
                                 .Include("Vehiculos")
                                 .AsNoTracking()
                                 .Where(r => r.IdCatalogos == id)
                                 select catalogo)
                                 .ToList();

            var catalogos = Mapper.Map<List<CatalogosData>, List<Catalogos>>(catalogosData);
            return catalogos;
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Catalogos/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Catalogos> ListarCatalogoses()
        {
            var catalogosData = (from catalogo in this.context.Catalogos
                                 .Include("Sistemas")
                                 .Include("SubSistemas")
                                 .Include("Vehiculos")
                                 .AsNoTracking()
                                 select catalogo)
                                 .ToList();

            var catalogos = Mapper.Map<List<CatalogosData>, List<Catalogos>>(catalogosData);
            return catalogos;
        }
    }
}