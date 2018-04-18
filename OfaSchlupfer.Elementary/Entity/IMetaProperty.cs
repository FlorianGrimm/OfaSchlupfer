namespace OfaSchlupfer.Entity {
    /// <summary>
    /// Defines a property.
    /// </summary>
    public interface IMetaProperty {
        /// <summary>
        /// Get the MetaEntity.
        /// </summary>
        /// <returns>the MetaEntity.</returns>
        IMetaEntity MetaEntity { get; set; }

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

        /// <summary>
        /// Gets or sets the property type.
        /// </summary>
        System.Type PropertyType { get; set; }
    }

    /// <summary>
    /// A property with index
    /// </summary>
    public interface IMetaIndexedProperty : IMetaProperty {
        /// <summary>
        /// Gets or sets the index
        /// </summary>
        int Index { get; set; }
    }
}
