// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPaisesValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddPaisesValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Paises
{
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add pais validador.</summary>
    public class AddPaisesValidador : AbstractValidator<Paises>
    {
        /// <summary>The pais repository.</summary>
        private readonly IRepositorio<Paises> paisRepository;

        /// <summary>Initializes a new instance of the <see cref="AddPaisesValidador"/> class. Initializes a new instance of the <see cref="PaisesValidador"/> class.</summary>
        /// <param name="paisRepository"></param>
        public AddPaisesValidador(IRepositorio<Paises> paisRepository)
        {
            this.paisRepository = paisRepository;
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.IdPaises).Must(this.NoExisteOtroPaises).WithMessage($"Ya existe otro Paises con el mismo identificador");
            this.RuleFor(r => r.CodigoDian).Must(this.NoExisteOtroCodigoDian).WithMessage($"Ya existe otro Código Dian");
            this.RuleFor(r => r.Codigo).Must(this.NoExisteOtroCodigo).WithMessage($"Ya existe otro Código");
            this.RuleFor(r => r.Nombre).Must(this.NoExisteOtroNombre).WithMessage($"Ya existe otro País con el mismo nombre");
        }

        /// <summary>The no existe otro pais.</summary>
        /// <param name="idPaises">The id pais.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroPaises(int idPaises)
        {
            return this.paisRepository.ObtenerPorId(idPaises) == null;
        }

        /// <summary>The no existe otro codigo dian.</summary>
        /// <param name="codigoDian">The codigo dian.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroCodigoDian(string codigoDian)
        {
            if (!string.IsNullOrWhiteSpace(codigoDian))
            {
                return !this.paisRepository.Obtener(paises => paises.CodigoDian.Equals(codigoDian)).Any();
            }

            return true;
        }

        /// <summary>The no existe otro nombre.</summary>
        /// <param name="nombre">The nombre.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroNombre(string nombre)
        {
            return !this.paisRepository.Obtener(paises => paises.Nombre.Equals(nombre)).Any();
        }

        private bool NoExisteOtroCodigo(string codigo)
        {
            return !this.paisRepository.Obtener(paises => paises.Codigo.Equals(codigo)).Any();
        }
    }
}