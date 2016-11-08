// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SistemasServicios.cs" company="">
//   
// </copyright>
// <summary>
//   The estado maestras servicios.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Administracion.Producto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Dominio.Entidades.Modelos.Productos;
    using Dominio.Interfaces.Administracion.Productos;

    using Feroza.VirtualPartes.Servicios.Interfaces.Extensions;

    using FluentValidation;

    using Validadores.Administracion.Producto.Sistemas;

    /// <summary>
    /// The estado maestras servicios.
    /// </summary>
    public class SistemasServicios : ISistemasServicio
    {
        /// <summary>The sistemas repositorio.</summary>
        private readonly IUnidadDeTrabajoProductos unidadDeTrabajoProductos;

        /// <summary>The validator factory.</summary>
        public readonly IValidatorFactory validatorFactory;

        /// <summary>Initializes a new instance of the <see cref="SistemasServicios"/> class.</summary>
        /// <param name="unidadDeTrabajoProductos.SistemasRepositorio">The sistemas repositorio.</param>
        /// <param name="validatorFactory">The validator Factory.</param>
        public SistemasServicios(IUnidadDeTrabajoProductos unidadDeTrabajoProductos, IValidatorFactory validatorFactory)
        {
            this.unidadDeTrabajoProductos = unidadDeTrabajoProductos;
            this.validatorFactory = validatorFactory;
        }

        /// <summary>The add sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        public void Add(Sistemas sistemas)
        {
            var addSistemasValidador = new AddSistemasValidador(this.unidadDeTrabajoProductos.SistemasRepositorio);
            var addSistemasValidadorResultado = addSistemasValidador.Validate(sistemas);

            if (!addSistemasValidadorResultado.IsValid)
            {
                throw new ValidationException(addSistemasValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.SistemasRepositorio.Insertar(sistemas);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The edit sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <exception cref="ValidationException"></exception>
        public void Edit(Sistemas sistemas)
        {
            var editSistemasValidador = new EditSistemasValidador(this.unidadDeTrabajoProductos.SistemasRepositorio);
            var editSistemasValidadorResultado = editSistemasValidador.Validate(sistemas);

            if (!editSistemasValidadorResultado.IsValid)
            {
                throw new ValidationException(editSistemasValidadorResultado.Errors);
            }

            this.unidadDeTrabajoProductos.SistemasRepositorio.Actualizar(sistemas);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The delete sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        public void Delete(Sistemas sistemas)
        {
            this.unidadDeTrabajoProductos.SistemasRepositorio.Eliminar(sistemas);
            this.unidadDeTrabajoProductos.Confirmar();
        }

        /// <summary>The list sistemas.</summary>
        /// <param name="idSistemas">The id sistemas.</param>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public Sistemas Get(int idSistemas)
        {
            return this.unidadDeTrabajoProductos.SistemasRepositorio.ObtenerPorId(idSistemas);
        }

        /// <summary>The list sistemas.</summary>
        /// <returns>The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        /// .</returns>
        public IList<Sistemas> List()
        {
            try
            {
                var sistemasList = this.unidadDeTrabajoProductos.SistemasRepositorio.Obtener(null, null, sistemas => sistemas.TiposProductos).OrderBy(r => r.Posicion).ToList();

                return sistemasList.ObtenerRelacionSistemaPadreSitemasHijos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>The list sistemas filtered.</summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IList"/>.</returns>
        /// <exception cref="Exception"></exception>
        public IList<Sistemas> ListFiltered(Expression<Func<Sistemas, bool>> filter)
        {
            try
            {
                return this.unidadDeTrabajoProductos.SistemasRepositorio.Obtener(filter).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}