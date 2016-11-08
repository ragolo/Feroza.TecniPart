// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddMarcasValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddMarcasValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Servicios.Interfaces.Validadores.Administracion.Marcas
{
    using System.Linq;

    using Dominio.Entidades.Modelos;

    using Feroza.VirtualPartes.Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add marcas validador.</summary>
    public class AddMarcasValidador : AbstractValidator<Marcas>
    {
        private readonly IRepositorio<Marcas> marcasRepository;

        /// <summary>Initializes a new instance of the <see cref="AddMarcasValidador"/> class. Initializes a new instance of the <see cref="MarcasValidador"/> class.</summary>
        /// <param name="marcasRepository"></param>
        public AddMarcasValidador(IRepositorio<Marcas> marcasRepository)
        {
            this.marcasRepository = marcasRepository;
            this.RuleFor(r => r.Nombre).NotEmpty();
            this.RuleFor(r => r.Sigla).NotEmpty();

            this.RuleFor(r => r.IdMarcas).Must(this.NoExisteOtroMarcas).WithMessage($"Ya existe otro Marcas con el mismo identificador");
            this.RuleFor(r => r.Nombre).Must(this.NoExisteOtraDescripcionMarca).WithMessage($"Ya existe otra Marca con el mismo nombre");
            this.RuleFor(r => r.Sigla).Must(this.NoExisteOtraSigla).WithMessage($"Ya existe otra Marca con la misma sigla");
        }

        /// <summary>The no existe otro marcas.</summary>
        /// <param name="idMarcas">The id marcas.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroMarcas(int idMarcas)
        {
            return this.marcasRepository.ObtenerPorId(idMarcas) == null;
        }

        /// <summary>The no existe otra descripcion marca.</summary>
        /// <param name="descripcion">The descripcion.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraDescripcionMarca(string descripcion)
        {
            return !this.marcasRepository.Obtener(r => r.Descripcion.Equals(descripcion)).Any();
        }

        /// <summary>The no existe otra sigla.</summary>
        /// <param name="sigla">The sigla.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtraSigla(string sigla)
        {
            return !this.marcasRepository.Obtener(r => r.Sigla.Equals(sigla)).Any();
        }
    }
}