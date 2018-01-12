namespace OfaSchlupfer.Elementary.Immutable {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Builder
    /// </summary>
    /// <typeparam name="M">The immutable model.</typeparam>
    public interface IBuilder<M> {
        /// <summary>
        /// Gets a frozen target.
        /// </summary>
        /// <returns>A frozen target.</returns>
        M GetTarget();
    }
}
