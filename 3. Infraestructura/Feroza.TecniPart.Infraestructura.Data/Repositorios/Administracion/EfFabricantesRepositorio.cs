// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfFabricantesRepositorio.cs" company="Feroza">
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
    public class EfFabricantesRepositorio : IFabricantesRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfFabricantesRepositorio"/> class.</summary>
        public EfFabricantesRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="fabricantes">The estado Maestras.</param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        public Fabricantes Crear(Fabricantes fabricantes)
        {
            var fabricantesDataOriginal = this.context.Fabricantes.FirstOrDefault(r => r.IdFabricantes == fabricantes.IdFabricantes);

            if (fabricantesDataOriginal == null || fabricantes.IdFabricantes == 0)
            {
                fabricantesDataOriginal = this.context.Fabricantes.Create();
                fabricantesDataOriginal.Descripcion = fabricantes.Descripcion;
                fabricantesDataOriginal.IdPais = fabricantes.IdPais;
                this.context.Fabricantes.Add(fabricantesDataOriginal);
                this.context.SaveChanges();
                fabricantes.IdFabricantes = fabricantesDataOriginal.IdFabricantes;
                fabricantes.Pais = new Pais { Descripcion = fabricantesDataOriginal.Pais.Descripcion, IdPais = fabricantesDataOriginal.Pais.IdPais };
                return fabricantes;
            }

            throw new Exception($"El fabricante ya existe {fabricantes.IdFabricantes}");
        }

        /// <summary>The editar.</summary>
        /// <param name="fabricantes">The estado maestras.</param>
        /// <returns>The <see cref="Fabricantes"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Fabricantes Editar(Fabricantes fabricantes)
        {
            var fabricantesDataOriginal = this.context.Fabricantes.FirstOrDefault(r => r.IdFabricantes == fabricantes.IdFabricantes);


            if (fabricantesDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var fabricantesDataMap = new FabricantesData
                {
                    IdFabricantes = fabricantes.IdFabricantes,
                    Descripcion = fabricantes.Descripcion,
                    IdPais = fabricantes.IdPais
                };
                fabricantesDataMap.IdFabricantes = fabricantesDataOriginal.IdFabricantes;
                this.context.Entry(fabricantesDataOriginal).CurrentValues.SetValues(fabricantesDataMap);
                this.context.SaveChanges();
                return fabricantes;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {fabricantes.IdFabricantes}");
        }

        /// <summary>The eliminar.</summary>
        /// <param name="id">The id.</param>
        public void Eliminar(int id)
        {
            var fabricantesToDelete = this.context.Fabricantes.FirstOrDefault(r => r.IdFabricantes.Equals(id));
            this.context.Fabricantes.Remove(fabricantesToDelete);
            this.context.SaveChanges();
        }

        /// <summary>The listar estado maestras.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<Fabricantes> ListarFabricantes(int id)
        {
            return this.context.Fabricantes.Where(r => r.IdFabricantes == id).Select(s => new Fabricantes
            {
                Descripcion = s.Descripcion,
                IdFabricantes = s.IdFabricantes,
                IdPais = s.IdPais,
                ImagenFabricante = s.ImagenFabricante,
                Pais = new Pais
                {
                    Descripcion = s.Descripcion,
                    IdPais = s.IdPais
                }
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Fabricantes/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Fabricantes> ListarFabricanteses()
        {
            return this.context.Fabricantes
                .Select(s => new Fabricantes
                {
                    Descripcion = s.Descripcion,
                    IdFabricantes = s.IdFabricantes,
                    IdPais = s.IdPais,
                    Pais = new Pais()
                    {
                        Descripcion = s.Pais.Descripcion,
                        IdPais = s.IdPais
                    }
                });
        }
    }
}