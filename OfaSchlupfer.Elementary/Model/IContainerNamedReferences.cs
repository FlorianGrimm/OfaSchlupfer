namespace OfaSchlupfer.Model {
    /// <summary>
    /// Model Object that is uses name nad reference
    /// </summary>
    public interface IContainerNamedReferences {
        /// <summary>
        /// Resolves all pairs name - reference.
        /// </summary>
        /// <param name="errors">error feedback</param>
        void ResolveNamedReferences(ModelErrors errors);
    }
}
