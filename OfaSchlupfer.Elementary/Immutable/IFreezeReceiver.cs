namespace OfaSchlupfer.Elementary.Immutable {
    /// <summary>
    /// Receiver for freeze and unfreeze
    /// </summary>
    public interface IFreezeReceiver {
        /// <summary>
        /// IBuildTarget was frozen.
        /// </summary>
        /// <param name="frozen">the frozen instance.</param>
        /// <returns>if true remove this from list</returns>
        bool HandleFreeze(IBuildTarget frozen);

        /// <summary>
        /// IBuildTarget was unrozen.
        /// </summary>
        /// <param name="previous">the old (may be frozen) instance.</param>
        /// <param name="next">the unfrozen instance</param>
        /// <returns>if true remove this from list</returns>
        bool HandleUnFreeze(IBuildTarget previous, IBuildTarget next);
    }
}