namespace OfaSchlupfer.Entitiy {
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

        /// <summary>
        /// validate the type of value.
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="validateOrThrow">false - return a message or true - throw an exception.</param>
        /// <returns>an error message or null.</returns>
        string Validate(object value, bool validateOrThrow);
    }
}
