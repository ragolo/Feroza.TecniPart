// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTiposProductosValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddTiposProductosValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.TiposProductos
{
    using Dominio.Entidades.Modelos.Productos;

    using Dominio.RepositorioContratos;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add lineasProductos validador.</summary>
    public class EditTiposProductosValidador : AbstractValidator<TiposProductos>
    {
        /// <summary>The lineasProductos repository.</summary>
        private readonly IRepositorio<TiposProductos> lineasProductosRepository;

        /// <summary>Initializes a new instance of the <see cref="EditTiposProductosValidador"/> class. Initializes a new instance of the <see cref="TiposProductosValidador"/> class.</summary>
        /// <param name="lineasProductosRepository">The lineasProductos Repository.</param>
        public EditTiposProductosValidador(IRepositorio<TiposProductos> lineasProductosRepository)
        {
            this.lineasProductosRepository = lineasProductosRepository;
            this.RuleFor(r => r.IdTiposProductos).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.Custom(r => this.NoExisteOtroTiposProductos(r));
        }

        /// <summary>The no existe otro lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroTiposProductos(TiposProductos lineasProductos)
        {
            //if (this.lineasProductosRepository.GetFiltered(r => r.IdTiposProductos == lineasProductos.IdTiposProductos && r.Descripcion.Equals(lineasProductos.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro TiposProductos con el mismo identificador");
            //}

            return null;
        }
    }
}