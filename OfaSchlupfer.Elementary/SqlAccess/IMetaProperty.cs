namespace OfaSchlupfer.SqlAccess {
    /// <summary>
    /// Defines a property.
    /// </summary>
    public interface IMetaProperty {
        /// <summary>
        /// Gets the definition of an property
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get an bound accessor
        /// </summary>
        /// <param name="entity">the entity to access</param>
        /// <returns>the bound accessor</returns>
        IAccessor GetAccessor(object entity);
    }
}
