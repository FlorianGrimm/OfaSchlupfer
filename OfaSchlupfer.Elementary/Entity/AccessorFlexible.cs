namespace OfaSchlupfer.Entity {
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// the accessor to the value.
    /// </summary>
    public struct AccessorFlexible : IAccessor {
        private readonly IEntityFlexible _Entity;
        private readonly IMetaIndexedProperty _MetaProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorFlexible"/> struct.
        /// </summary>
        /// <param name="metaPropertyArrayProp">the property</param>
        /// <param name="entity">the entity</param>
        public AccessorFlexible(IMetaIndexedProperty metaPropertyArrayProp, IEntityFlexible entity) {
            this._MetaProperty = metaPropertyArrayProp;
            this._Entity = entity;
        }

        /// <summary>
        /// Gets the metaproperty
        /// </summary>
        public IMetaProperty MetaProperty { get { return this._MetaProperty; } }

        /// <summary>
        /// Gets or sets the value of the property of entity
        /// </summary>
        public object Value {
            get {

                return this._Entity.GetObjectValue(this._MetaProperty.Index);
            }

            set {
                // this._Entity.ThrowIfFrozen();
                this._MetaProperty.Validate(value, false);
                this._Entity.SetObjectValue(this._MetaProperty.Index, value);
            }
        }
    }
}