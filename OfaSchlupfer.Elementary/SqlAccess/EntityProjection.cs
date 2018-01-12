namespace OfaSchlupfer.Elementary.SqlAccess {
    /// <summary>
    /// An entity that project properties
    /// </summary>
    public class EntityProjection : IEntity {
        /// <summary>
        /// the source entity
        /// </summary>
        internal readonly IEntity _ProjectedEntity;

        /// <summary>
        /// MetaData
        /// </summary>
        internal readonly MetaEntityProjection _MetaData;

        /// <summary>
        /// Gets the Metadata
        /// </summary>
        public IMetaEntity MetaData { get { return this._MetaData; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityProjection"/> class.
        /// </summary>
        /// <param name="metaData">the meta data.</param>
        /// <param name="entity">the entity.</param>
        public EntityProjection(MetaEntityProjection metaData, IEntity entity) {
            this._ProjectedEntity = entity;
            this._MetaData = metaData;
        }
    }
}
