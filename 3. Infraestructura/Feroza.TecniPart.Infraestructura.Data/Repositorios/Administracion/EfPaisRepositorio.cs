// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfPaisRepositorio.cs" company="Feroza">
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
    public class EfPaisRepositorio : IPaisRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfPaisRepositorio"/> class.</summary>
        public EfPaisRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="pais">The estado Maestras.</param>
        /// <returns>The <see cref="Pais"/>.</returns>
        public Pais Crear(Pais pais)
        {
            var paisDataOriginal = this.context.Pais.FirstOrDefault(r => r.IdPais == pais.IdPais);

            if (paisDataOriginal == null || pais.IdPais == 0)
            {
                paisDataOriginal = this.context.Pais.Create();
                paisDataOriginal.Descripcion = pais.Descripcion;
                this.context.Pais.Add(paisDataOriginal);
                this.context.SaveChanges();
                pais.IdPais = paisDataOriginal.IdPais;
                return pais;
            }

            throw new Exception($"El estado maestra ya existe {pais.IdPais}");
        }

        /// <summary>The editar.</summary>
        /// <param name="pais">The estado maestras.</param>
        /// <returns>The <see cref="Pais"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Pais Editar(Pais pais)
        {
            var paisDataOriginal = this.context.Pais.FirstOrDefault(r => r.IdPais == pais.IdPais);


            if (paisDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var paisDataMap = new PaisData
                {
                    IdEstadoMaestras = pais.IdEstadoMaestras,
                    IdPais = pais.IdPais,
                    Descripcion = pais.Descripcion
                };
                paisDataMap.IdPais = paisDataOriginal.IdPais;
                this.context.Entry(paisDataOriginal).CurrentValues.SetValues(paisDataMap);
                this.context.SaveChanges();
                return pais;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {pais.IdPais}");
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idPais">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idPais)
        {
            var paisToDelete = this.context.Pais.FirstOrDefault(r => r.IdPais.Equals(idPais));
            this.context.Pais.Remove(paisToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idPais">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Pais> ListarPais(int idPais)
        {
            return this.context.Pais.Where(r => r.IdPais == idPais).Select(s => new Pais
            {
                Descripcion = s.Descripcion,
                IdPais = s.IdPais
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Pais/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Pais> ListarPaises()
        {
            return this.context.Pais.Select(s => new Pais
            {
                Descripcion = s.Descripcion,
                IdPais = s.IdPais
            });
        }
    }
}