// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfSubSistemasRepositorio.cs" company="Feroza">
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
    public class EfSubSistemasRepositorio : ISubSistemasRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfSubSistemasRepositorio"/> class.</summary>
        public EfSubSistemasRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="subSistemas">The subSistemas.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        /// <exception cref="Exception"></exception>
        public SubSistemas Crear(SubSistemas subSistemas)
        {
            var subSistemasDataOriginal = this.context.SubSistemas.FirstOrDefault(r => r.IdSubSistemas == subSistemas.IdSubSistemas);

            if (subSistemasDataOriginal == null || subSistemas.IdSubSistemas == 0)
            {
                subSistemasDataOriginal = this.context.SubSistemas.Create();
                subSistemasDataOriginal.Descripcion = subSistemas.Descripcion;
                subSistemasDataOriginal.IdSubSistemas = subSistemas.IdSubSistemas;
                subSistemasDataOriginal.IdSistemas = subSistemas.IdSistemas;

                this.context.SubSistemas.Add(subSistemasDataOriginal);
                this.context.SaveChanges();
                subSistemas.IdSubSistemas = subSistemasDataOriginal.IdSubSistemas;
                subSistemas.Sistemas = new Sistemas()
                {
                    Descripcion = subSistemasDataOriginal.Sistemas.Descripcion,
                    Posicion = subSistemasDataOriginal.Sistemas.Posicion,
                    IdSistemas = subSistemasDataOriginal.Sistemas.IdSistemas
                };
                return subSistemas;
            }

            throw new Exception($"El sub-sitema ya existe {subSistemas.IdSubSistemas}");
        }

        /// <summary>The editar.</summary>
        /// <param name="subSistemas">The estado maestras.</param>
        /// <returns>The <see cref="SubSistemas"/>.</returns>
        /// <exception cref="Exception"></exception>
        public SubSistemas Editar(SubSistemas subSistemas)
        {
            var subSistemasDataOriginal = this.context.SubSistemas.FirstOrDefault(r => r.IdSubSistemas == subSistemas.IdSubSistemas);


            if (subSistemasDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var subSistemasDataMap = new SubSistemasData
                {
                    IdSubSistemas = subSistemas.IdSubSistemas,
                    Descripcion = subSistemas.Descripcion,
                    IdSistemas = subSistemas.IdSistemas
                };
                subSistemasDataMap.IdSubSistemas = subSistemasDataOriginal.IdSubSistemas;
                this.context.Entry(subSistemasDataOriginal).CurrentValues.SetValues(subSistemasDataMap);
                this.context.SaveChanges();
                return subSistemas;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {subSistemas.IdSubSistemas}");
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idSubSistemas">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idSubSistemas)
        {
            var subSistemasToDelete = this.context.SubSistemas.FirstOrDefault(r => r.IdSubSistemas.Equals(idSubSistemas));
            this.context.SubSistemas.Remove(subSistemasToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idSubSistemas">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<SubSistemas> ListarSubSistemas(int idSubSistemas)
        {
            return this.context.SubSistemas.Where(r => r.IdSubSistemas == idSubSistemas).Select(s => new SubSistemas
            {
                Descripcion = s.Descripcion,
                IdSubSistemas = s.IdSubSistemas,
                IdSistemas = s.IdSistemas,
                Sistemas = new Sistemas()
                {
                    Descripcion = s.Sistemas.Descripcion,
                    IdSistemas = s.Sistemas.IdSistemas,
                    Posicion = s.Sistemas.Posicion
                }
            }).ToList();
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<SubSistemas/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<SubSistemas> ListarSubSistemases()
        {
            return this.context.SubSistemas.Select(s => new SubSistemas
            {
                Descripcion = s.Descripcion,
                IdSubSistemas = s.IdSubSistemas,
                IdSistemas = s.IdSistemas,
                Sistemas = new Sistemas()
                {
                    Descripcion = s.Sistemas.Descripcion,
                    IdSistemas = s.Sistemas.IdSistemas,
                    Posicion = s.Sistemas.Posicion
                }
            }).ToList();
        }
    }
}