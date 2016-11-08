// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddLineasProductosValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddLineasProductosValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.LineasProductos
{
    using Dominio.Entidades.Modelos.Productos;

    using Dominio.RepositorioContratos;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add lineasProductos validador.</summary>
    public class EditLineasProductosValidador : AbstractValidator<LineasProductos>
    {
        /// <summary>The lineasProductos repository.</summary>
        private readonly IRepositorio<LineasProductos> lineasProductosRepository;

        /// <summary>Initializes a new instance of the <see cref="EditLineasProductosValidador"/> class. Initializes a new instance of the <see cref="LineasProductosValidador"/> class.</summary>
        /// <param name="lineasProductosRepository">The lineasProductos Repository.</param>
        public EditLineasProductosValidador(IRepositorio<LineasProductos> lineasProductosRepository)
        {
            this.lineasProductosRepository = lineasProductosRepository;
            this.RuleFor(r => r.IdLineasProductos).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.Custom(r => this.NoExisteOtroLineasProductos(r));
        }

        /// <summary>The no existe otro lineasProductos.</summary>
        /// <param name="lineasProductos">The lineasProductos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroLineasProductos(LineasProductos lineasProductos)
        {
            //if (this.lineasProductosRepository.GetFiltered(r => r.IdLineasProductos == lineasProductos.IdLineasProductos && r.Descripcion.Equals(lineasProductos.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro LineasProductos con el mismo identificador");
            //}

            return null;
        }
    }
}