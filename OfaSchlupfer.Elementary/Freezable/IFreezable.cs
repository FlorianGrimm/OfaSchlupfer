namespace OfaSchlupfer.Freezable {
    /// <summary>
    /// freeze to (observable) immutablitiy
    /// </summary>
    public interface IFreezable {
        /// <summary>
        /// Freeze the object
        /// </summary>
        /// <returns>true if changed to frozen.</returns>
        bool Freeze();

        /// <summary>
        /// is object rozen.
        /// </summary>
        /// <returns>object is frozen.</returns>
        bool IsFrozen();
    }
}
