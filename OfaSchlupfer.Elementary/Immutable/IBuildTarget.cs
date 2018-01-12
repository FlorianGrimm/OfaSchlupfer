namespace OfaSchlupfer.Elementary.Immutable {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Freeze andd unFreeze
    /// </summary>
    public interface IBuildTarget {
        /// <summary>
        /// Gets a value indicating whether this instance is frozen.
        /// </summary>
        bool IsFrozen { get; }

        /// <summary>
        /// Freeze this instance.
        /// </summary>
        void Freeze();

        /// <summary>
        /// Add FreezeHandler
        /// </summary>
        /// <param name="freezeReceiver">freezeReceiver</param>
        void AddFreezeReceiver(IFreezeReceiver freezeReceiver);

        /// <summary>
        /// UnFreeze means clone and return the new instance if frozen.
        /// </summary>
        /// <param name="cloneAlways">clone</param>
        /// <returns>a clone or this if not frozen.</returns>
        IBuildTarget UnFreeze(bool cloneAlways = false);
    }
}
