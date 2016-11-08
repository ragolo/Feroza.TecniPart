// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddMarcasTiposProductosValidador.cs" company="">
//   
// </copyright>
// <summary>
//   The add marcasTiposProductos validador.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.MarcasTiposProductos
{
    using Dominio.Entidades.Modelos.Productos;
    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add marcasTiposProductos validador.</summary>
    public class AddMarcasTiposProductosValidador : AbstractValidator<MarcasTiposProductos>
    {
        /// <summary>The lineas productos repository.</summary>
        private readonly IRepositorio<MarcasTiposProductos> marcasTiposProductosRepository;

        /// <summary>Initializes a new instance of the <see cref="AddMarcasTiposProductosValidador"/> class. Initializes a new instance of the <see cref="MarcasTiposProductosValidador"/> class.</summary>
        /// <param name="marcasTiposProductosRepository"></param>
        public AddMarcasTiposProductosValidador(IRepositorio<MarcasTiposProductos> marcasTiposProductosRepository)
        {
            this.marcasTiposProductosRepository = marcasTiposProductosRepository;
            this.RuleFor(r => r.IdMarca).NotEmpty().GreaterThanOrEqualTo(1);
            this.RuleFor(r => r.IdTiposProductos).NotEmpty().GreaterThanOrEqualTo(1);
            this.RuleFor(r => r.IdMarcasTiposProductos).Must(this.NoExisteOtroMarcasTiposProductos).WithMessage($"Ya existe otro MarcasTiposProductos con el mismo identificador");
        }

        /// <summary>The no existe otro marcasTiposProductos.</summary>
        /// <param name="idMarcasTiposProductos">The id marcasTiposProductos.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroMarcasTiposProductos(int idMarcasTiposProductos)
        {
            return this.marcasTiposProductosRepository.ObtenerPorId(idMarcasTiposProductos) == null;
        }
    }
}