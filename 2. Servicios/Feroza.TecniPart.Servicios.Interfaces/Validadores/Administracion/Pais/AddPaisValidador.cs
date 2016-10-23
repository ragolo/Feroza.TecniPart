// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPaisValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddPaisValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Pais
{
    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;

    /// <summary>The add pais validador.</summary>
    public class AddPaisValidador : AbstractValidator<Pais>
    {
        private readonly IRepository<Pais> paisRepository;

        /// <summary>Initializes a new instance of the <see cref="AddPaisValidador"/> class. Initializes a new instance of the <see cref="PaisValidador"/> class.</summary>
        /// <param name="paisRepository"></param>
        public AddPaisValidador(IRepository<Pais> paisRepository)
        {
            this.paisRepository = paisRepository;
            this.RuleFor(r => r.IdPais).NotEmpty().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdDane).NotEmpty();
            this.RuleFor(r => r.IdPais).Must(this.NoExisteOtroPais).WithMessage($"Ya existe otro Pais con el mismo identificador");
        }

        /// <summary>The no existe otro pais.</summary>
        /// <param name="idPais">The id pais.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroPais(int idPais)
        {
            return paisRepository.GetById(idPais) == null;
        }
    }
}