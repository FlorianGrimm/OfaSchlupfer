namespace OfaSchlupfer.SqlAccess {
    /// <summary>
    /// a Entity
    /// </summary>
    public interface IEntity {
        /// <summary>
        /// Gets the metadata.
        /// </summary>
        IMetaEntity MetaData { get; }
    }
}
