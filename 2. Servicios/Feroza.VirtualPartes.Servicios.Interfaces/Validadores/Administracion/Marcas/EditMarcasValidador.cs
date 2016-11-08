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
    using Dominio.Entidades.Modelos;

    using Dominio.RepositorioContratos;

    using FluentValidation;

    /// <summary>The add fabricantes validador.</summary>
    public class EditMarcasValidador : AbstractValidator<Marcas>
    {
        /// <summary>The fabricantes repository.</summary>
        private readonly IRepositorio<Marcas> fabricantesRepository;

        /// <summary>Initializes a new instance of the <see cref="EditMarcasValidador"/> class. Initializes a new instance of the <see cref="MarcasValidador"/> class.</summary>
        /// <param name="fabricantesRepository">The fabricantes Repository.</param>
        public EditMarcasValidador(IRepositorio<Marcas> fabricantesRepository)
        {
            this.fabricantesRepository = fabricantesRepository;
            this.RuleFor(r => r.IdMarcas).GreaterThanOrEqualTo(0);
            this.RuleFor(r => r.Descripcion).NotEmpty();
            this.RuleFor(r => r.Sigla).NotEmpty();
        }
    }
}