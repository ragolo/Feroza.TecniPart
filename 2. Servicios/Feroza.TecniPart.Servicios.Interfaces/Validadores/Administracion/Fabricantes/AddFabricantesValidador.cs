// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddFabricantesValidador.cs" company="Feroza">
//   Feroza
// </copyright>
// <summary>
//   Defines the AddFabricantesValidador type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.TecniPart.Servicios.Interfaces.Validadores.Administracion.Fabricantes
{
    using Dominio.Entidades.Modelos;

    using Dominio.Interfaces.Repositorio;

    using FluentValidation;

    /// <summary>The add fabricantes validador.</summary>
    public class AddFabricantesValidador : AbstractValidator<Fabricantes>
    {
        private readonly IRepository<Fabricantes> fabricantesRepository;

        /// <summary>Initializes a new instance of the <see cref="AddFabricantesValidador"/> class. Initializes a new instance of the <see cref="FabricantesValidador"/> class.</summary>
        /// <param name="fabricantesRepository"></param>
        public AddFabricantesValidador(IRepository<Fabricantes> fabricantesRepository)
        {
            this.fabricantesRepository = fabricantesRepository;
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.IdPais).NotNull().GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.IdFabricantes).Must(this.NoExisteOtroFabricantes).WithMessage($"Ya existe otro Fabricantes con el mismo identificador");
        }

        /// <summary>The no existe otro fabricantes.</summary>
        /// <param name="idFabricantes">The id fabricantes.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool NoExisteOtroFabricantes(int idFabricantes)
        {
            return this.fabricantesRepository.GetById(idFabricantes) == null;
        }
    }
}