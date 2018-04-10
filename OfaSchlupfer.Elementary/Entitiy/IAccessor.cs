namespace OfaSchlupfer.Entitiy {
    /// <summary>
    /// a bound property
    /// </summary>
    public interface IAccessor {
        /// <summary>
        /// Gets the metadata of the property
        /// </summary>
        IMetaProperty MetaProperty { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        object Value { get; set; }
    }
}
