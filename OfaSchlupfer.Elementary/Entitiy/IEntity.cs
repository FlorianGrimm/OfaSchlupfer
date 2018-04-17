namespace OfaSchlupfer.Entity {
    /// <summary>
    /// a Entity
    /// </summary>
    public interface IEntity {
        /// <summary>
        /// Gets the metadata.
        /// </summary>
        IMetaEntity MetaData { get; }
    }

    public interface IEntityArrayValues {

        /// <summary>
        /// INTERNAL
        /// Get the object value
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>the value</returns>
        object GetObjectValue(int index);

        /// <summary>
        /// INTERNAL
        /// Set the value at the index
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="value">the new value</param>
        void SetObjectValue(int index, object value);
    }
}
