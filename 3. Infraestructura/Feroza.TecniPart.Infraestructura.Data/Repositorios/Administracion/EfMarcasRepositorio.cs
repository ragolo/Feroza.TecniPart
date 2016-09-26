// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EfMarcasRepositorio.cs" company="Feroza">
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
    public class EfMarcasRepositorio : IMarcasRespositorio
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TecniPartEntities context;

        /// <summary>Initializes a new instance of the <see cref="EfMarcasRepositorio"/> class.</summary>
        public EfMarcasRepositorio()
        {
            this.context = new TecniPartEntities();
        }

        /// <summary>The crear.</summary>
        /// <param name="marcas">The estado Maestras.</param>
        /// <returns>The <see cref="Marcas"/>.</returns>
        public Marcas Crear(Marcas marcas)
        {
            var marcasDataOriginal = this.context.Marcas.FirstOrDefault(r => r.IdMarcas == marcas.IdMarcas);

            if (marcasDataOriginal == null || marcas.IdMarcas == 0)
            {
                marcasDataOriginal = this.context.Marcas.Create();
                marcasDataOriginal.Descripcion = marcas.Descripcion;
                marcasDataOriginal.Sigla = marcas.Sigla;
                this.context.Marcas.Add(marcasDataOriginal);
                this.context.SaveChanges();
                marcas.IdMarcas = marcasDataOriginal.IdMarcas;
                return marcas;
            }

            throw new Exception($"El estado maestra ya existe {marcas.IdMarcas}");
        }

        /// <summary>The editar.</summary>
        /// <param name="marcas">The estado maestras.</param>
        /// <returns>The <see cref="Marcas"/>.</returns>
        /// <exception cref="Exception"></exception>
        public Marcas Editar(Marcas marcas)
        {
            var marcasDataOriginal = this.context.Marcas.FirstOrDefault(r => r.IdMarcas == marcas.IdMarcas);


            if (marcasDataOriginal != null)
            {
                //TODO: Implementar auto mapper
                var marcasDataMap = new MarcasData
                {
                    IdMarcas = marcas.IdMarcas,
                    Descripcion = marcas.Descripcion,
                    Sigla = marcas.Sigla
                };
                marcasDataMap.IdMarcas = marcasDataOriginal.IdMarcas;
                this.context.Entry(marcasDataOriginal).CurrentValues.SetValues(marcasDataMap);
                this.context.SaveChanges();
                return marcas;
            }
            //TODO: Falta implementar Manejador de excepciones
            throw new Exception($"El estado maestra no existe {marcas.IdMarcas}");
        }

        /// <summary>
        /// The eliminar.
        /// </summary>
        /// <param name="idMarcas">
        /// The id estado maestras.
        /// </param>
        public void Eliminar(int idMarcas)
        {
            var marcasToDelete = this.context.Marcas.FirstOrDefault(r => r.IdMarcas.Equals(idMarcas));
            this.context.Marcas.Remove(marcasToDelete);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The listar estado maestras.
        /// </summary>
        /// <param name="idMarcas">
        /// The id estado maestras.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Marcas> ListarMarcas(int idMarcas)
        {
            return this.context.Marcas.Where(r => r.IdMarcas == idMarcas).Select(s => new Marcas
            {
                Descripcion = s.Descripcion,
                IdMarcas = s.IdMarcas,
                Sigla = s.Sigla
            });
        }

        /// <summary>The listar estado maestras.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable<Marcas/></cref>
        ///     </see>
        /// .</returns>
        public IEnumerable<Marcas> ListarMarcases()
        {
            return this.context.Marcas.Select(s => new Marcas
            {
                Descripcion = s.Descripcion,
                IdMarcas = s.IdMarcas,
                Sigla = s.Sigla
            });
        }
    }
}