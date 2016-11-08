// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddMarcasTiposProductosValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddMarcasTiposProductosValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.MarcasTiposProductos
{
    using Dominio.Entidades.Modelos.Productos;

    using Dominio.RepositorioContratos;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add marcasTiposProductos validador.</summary>
    public class EditMarcasTiposProductosValidador : AbstractValidator<MarcasTiposProductos>
    {
        /// <summary>The marcasTiposProductos repository.</summary>
        private readonly IRepositorio<MarcasTiposProductos> marcasTiposProductosRepository;

        /// <summary>Initializes a new instance of the <see cref="EditMarcasTiposProductosValidador"/> class. Initializes a new instance of the <see cref="MarcasTiposProductosValidador"/> class.</summary>
        /// <param name="marcasTiposProductosRepository">The marcasTiposProductos Repository.</param>
        public EditMarcasTiposProductosValidador(IRepositorio<MarcasTiposProductos> marcasTiposProductosRepository)
        {
            this.marcasTiposProductosRepository = marcasTiposProductosRepository;
            this.RuleFor(r => r.IdMarca).NotEmpty().GreaterThanOrEqualTo(1);
            this.RuleFor(r => r.IdTiposProductos).NotEmpty().GreaterThanOrEqualTo(1);
            this.Custom(r => this.NoExisteOtroMarcasTiposProductos(r));
        }

        /// <summary>The no existe otro marcasTiposProductos.</summary>
        /// <param name="marcasTiposProductos">The marcasTiposProductos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroMarcasTiposProductos(MarcasTiposProductos marcasTiposProductos)
        {
            //if (this.marcasTiposProductosRepository.GetFiltered(r => r.IdMarcasTiposProductos == marcasTiposProductos.IdMarcasTiposProductos && r.Descripcion.Equals(marcasTiposProductos.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro MarcasTiposProductos con el mismo identificador");
            //}

            return null;
        }
    }
}