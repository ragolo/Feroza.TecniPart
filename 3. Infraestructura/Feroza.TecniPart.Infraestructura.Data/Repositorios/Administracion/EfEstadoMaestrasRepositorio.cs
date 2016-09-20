// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfEstadoMaestrasRepositorio.cs" company="Feroza">
//   
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

    using Data;

    using Dominio.Entidades.Modelos;
    using Dominio.Interfaces.Administracion;

    /// <summary>
    /// The ef estado maestras repositorio.
    /// </summary>
    public class EfEstadoMaestrasRepositorio : IEstadoMaestrasRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfEstadoMaestrasRepositorio"/> class.
        /// </summary>
        public EfEstadoMaestrasRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="estadoMaestras">The estado Maestras.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        public EstadoMaestras Crear(EstadoMaestras estadoMaestras)
        {
            var estadoMaestrasDataOriginal = this.context.EstadoMaestras.FirstOrDefault(r => r.IdEstadoMaestras == estadoMaestras.IdEstadoMaestras);

            if (estadoMaestrasDataOriginal == null)
            {
                estadoMaestrasDataOriginal = this.context.EstadoMaestras.Create();
                estadoMaestrasDataOriginal.Descripcion = estadoMaestras.Descripcion;
                this.context.EstadoMaestras.Add(estadoMaestrasDataOriginal);
                this.context.SaveChanges();
                estadoMaestras.IdEstadoMaestras = estadoMaestrasDataOriginal.IdEstadoMaestras;
                return estadoMaestras;
            }

            throw new Exception($"El estado maestra ya existe {estadoMaestras.IdEstadoMaestras}");
        }

        /// <summary>The editar.</summary>
        /// <param name="estadoMaestras">The estado maestras.</param>
        /// <returns>The <see cref="EstadoMaestras"/>.</returns>
        /// <exception cref="Exception"></exception>
        public EstadoMaestras Editar(EstadoMaestras estadoMaestras)
        {
            var estadoMaestrasDataOriginal = this.context.EstadoMaestras.FirstOrDefault(r => r.IdEstadoMaestras == estadoMaestras.IdEstadoMaestras);


            if (estadoMaestrasDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var estadoMaestrasDataMap = new EstadoMaestrasData
                {
                    IdEstadoMaestras = estadoMaestras.IdEstadoMaestras,
                    Descripcion = estadoMaestras.Descripcion
                };
                estadoMaestrasDataMap.IdEstadoMaestras = estadoMaestrasDataOriginal.IdEstadoMaestras;
                this.context.Entry(estadoMaestrasDataOriginal).CurrentValues.SetValues(estadoMaestrasDataMap);
                this.context.SaveChanges();
                return estadoMaestras;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {estadoMaestras.IdEstadoMaestras}");
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idEstadoMaestras">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idEstadoMaestras)
        {
            var estadoMaestraToDelete = this.context.EstadoMaestras.FirstOrDefault(r => r.IdEstadoMaestras.Equals(idEstadoMaestras));
            if (estadoMaestraToDelete != null)
            {
                this.context.EstadoMaestras.Remove(estadoMaestraToDelete);
                this.context.SaveChanges();
            }
            else
            {
                throw new Exception($"El registro [{idEstadoMaestras}] que intenta eliminar, no fue encontrado.");
            }
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idEstadoMaestras">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<EstadoMaestras> ListarEstadoMaestras(int idEstadoMaestras)
        {
            return this.context.EstadoMaestras.Where(r => r.IdEstadoMaestras == idEstadoMaestras).Select(s => new EstadoMaestras
            {
                Descripcion = s.Descripcion,
                IdEstadoMaestras = s.IdEstadoMaestras
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<EstadoMaestras/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<EstadoMaestras> ListarEstadoMaestras()
        {
            return this.context.EstadoMaestras.Select(s => new EstadoMaestras
            {
                Descripcion = s.Descripcion,
                IdEstadoMaestras = s.IdEstadoMaestras
            });
        }
    }
}