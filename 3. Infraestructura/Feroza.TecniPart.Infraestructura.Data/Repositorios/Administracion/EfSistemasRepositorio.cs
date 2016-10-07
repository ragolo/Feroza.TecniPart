﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfSistemasRepositorio.cs" company="Feroza">
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

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The ef estado maestras repositorio.
    /// </summary>
    public class EfSistemasRepositorio : ISistemasRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfSistemasRepositorio"/> class.</summary>
        public EfSistemasRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Sistemas Crear(Sistemas sistemas)
        {
            var sistemasDataOriginal = this.context.Sistemas.FirstOrDefault(r => r.IdSistemas == sistemas.IdSistemas);

            if (sistemasDataOriginal == null || sistemas.IdSistemas == 0)
            {
                sistemasDataOriginal = this.context.Sistemas.Create();
                sistemasDataOriginal.Descripcion = sistemas.Descripcion;
                sistemasDataOriginal.IdSistemas = sistemas.IdSistemas;
                sistemasDataOriginal.Posicion = sistemas.Posicion;

                foreach (var subSistema in sistemas.SubSistemas)
                {
                    sistemasDataOriginal.SubSistemas.Add(new SubSistemasData()
                    {
                        Descripcion = subSistema.Descripcion,
                        IdSubSistemas = subSistema.IdSubSistemas,
                        IdSistemas = subSistema.IdSistemas
                    });
                }

                this.context.Sistemas.Add(sistemasDataOriginal);
                this.context.SaveChanges();
                sistemas.IdSistemas = sistemasDataOriginal.IdSistemas;
                return sistemas;
            }

            throw new Exception($"El sitema ya existe {sistemas.IdSistemas}");
        }

        /// <summary>The editar.</summary>
        /// <param name="sistemas">The estado maestras.</param>
        /// <returns>The <see cref="Sistemas"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Sistemas Editar(Sistemas sistemas)
        {
            var sistemasDataOriginal = this.context.Sistemas.FirstOrDefault(r => r.IdSistemas == sistemas.IdSistemas);


            if (sistemasDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var sistemasDataMap = new SistemasData
                {
                    IdSistemas = sistemas.IdSistemas,
                    Descripcion = sistemas.Descripcion,
                    Posicion = sistemas.Posicion
                };

                foreach (var subSistema in sistemas.SubSistemas)
                {
                    sistemasDataOriginal.SubSistemas.Add(new SubSistemasData()
                    {
                        Descripcion = subSistema.Descripcion,
                        IdSubSistemas = subSistema.IdSubSistemas,
                        IdSistemas = subSistema.IdSistemas
                    });
                }

                sistemasDataMap.IdSistemas = sistemasDataOriginal.IdSistemas;
                this.context.Entry(sistemasDataOriginal).CurrentValues.SetValues(sistemasDataMap);
                this.context.SaveChanges();
                return sistemas;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {sistemas.IdSistemas}");
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idSistemas">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idSistemas)
        {
            var sistemasToDelete = this.context.Sistemas.FirstOrDefault(r => r.IdSistemas.Equals(idSistemas));
            this.context.Sistemas.Remove(sistemasToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idSistemas">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Sistemas> ListarSistemas(int idSistemas)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SistemasData, Sistemas>();
                cfg.CreateMap<SubSistemasData, SubSistemas>();
                cfg.CreateMap<VehiculoSubSistemasData, VehiculoSubSistemas>();
                cfg.CreateMap<VehiculoSistemasData, VehiculoSistemas>();
            });

            var sistemas = this.context.Sistemas
                .Where(r => r.IdSistemas == idSistemas).ToList();
            return Mapper.Map<List<SistemasData>, List<Sistemas>>(sistemas);
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Sistemas/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Sistemas> ListarSistemases()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SistemasData, Sistemas>();
                cfg.CreateMap<SubSistemasData, SubSistemas>();
                cfg.CreateMap<VehiculoSubSistemasData, VehiculoSubSistemas>();
                cfg.CreateMap<VehiculoSistemasData, VehiculoSistemas>();
            });

            var sistemasData = (from sistema in this.context.Sistemas select sistema).ToArray();

            return Mapper.Map<IEnumerable<SistemasData>, IEnumerable<Sistemas>>(sistemasData);
        }
    }
}