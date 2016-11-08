// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSistemasValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddSistemasValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Producto.Sistemas
{
    using Dominio.Entidades.Modelos.Productos;

    using Dominio.RepositorioContratos;

    using FluentValidation;
    using FluentValidation.Results;

    /// <summary>The add sistemas validador.</summary>
    public class EditSistemasValidador : AbstractValidator<Sistemas>
    {
        /// <summary>The sistemas repository.</summary>
        private readonly IRepositorio<Sistemas> sistemasRepository;

        /// <summary>Initializes a new instance of the <see cref="EditSistemasValidador"/> class. Initializes a new instance of the <see cref="SistemasValidador"/> class.</summary>
        /// <param name="sistemasRepository">The sistemas Repository.</param>
        public EditSistemasValidador(IRepositorio<Sistemas> sistemasRepository)
        {
            this.sistemasRepository = sistemasRepository;
            this.RuleFor(r => r.IdSistemas).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.Custom(r => this.NoExisteOtroSistemas(r));
        }

        /// <summary>The no existe otro sistemas.</summary>
        /// <param name="sistemas">The sistemas.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private ValidationFailure NoExisteOtroSistemas(Sistemas sistemas)
        {
            //if (this.sistemasRepository.GetFiltered(r => r.IdSistemas == sistemas.IdSistemas && r.Descripcion.Equals(sistemas.Descripcion)).Any())
            //{
            //    throw new ValidationException($"Ya existe otro Sistemas con el mismo identificador");
            //}

            return null;
        }
    }
}