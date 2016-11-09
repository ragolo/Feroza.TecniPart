// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnidadDeTrabajo.cs" company="">
//   
// </copyright>
// <summary>
//   The unidad de trabajo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Feroza.VirtualPartes.Infraestructura.BaseData
{
    /// <summary>The unidad de trabajo.</summary>
    /// <typeparam name="TContexto"></typeparam>
    public class UnidadDeTrabajo<TContexto> : IUnidadDeTrabajo where TContexto : IContexto, new()
    {
        /// <summary>The context.</summary>
        private readonly IContexto context;

        /// <summary>Initializes a new instance of the <see cref="UnidadDeTrabajo{TContexto}"/> class.</summary>
        public UnidadDeTrabajo()
        {
            this.context = new TContexto();
        }

        /// <summary>Initializes a new instance of the <see cref="UnidadDeTrabajo{TContexto}"/> class.</summary>
        /// <param name="context">The context.</param>
        public UnidadDeTrabajo(IContexto context)
        {
            this.context = context;
        }

        /// <summary>Gets the contexto.</summary>
        public IContexto Contexto
        {
            get { return (TContexto)this.context; }
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>The guardar.</summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int Guardar()
        {
            return this.context.GuardarCambios();
        }
    }
}