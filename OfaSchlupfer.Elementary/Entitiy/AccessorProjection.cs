namespace OfaSchlupfer.Entitiy {
    using System;

    /// <summary>
    /// Accessor for projection
    /// </summary>
    public struct AccessorProjection : IAccessor {
        private readonly EntityProjection _Entity;
        private readonly MetaPropertyProjection _Property;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorProjection"/> struct.
        /// </summary>
        /// <param name="property">the property</param>
        /// <param name="entity">the entity</param>
        public AccessorProjection(MetaPropertyProjection property, EntityProjection entity) {
            this._Property = property;
            this._Entity = entity;
        }

        /// <summary>
        /// Gets the property
        /// </summary>
        public IMetaProperty MetaProperty { get { return this.MetaProperty; } }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value {
            get {
                var name = this._Property.ProjectedName ?? this._Property.Name;
                var metaProperty = this._Entity.MetaData.GetProperty(name);
                if (metaProperty == null) { throw new InvalidOperationException(string.Format("Property {0} not found.", name)); }
                return metaProperty.GetAccessor(this._Entity._ProjectedEntity).Value;
            }

            set {
                var name = this._Property.ProjectedName ?? this._Property.Name;
                var metaProperty = this._Entity.MetaData.GetProperty(name);
                if (metaProperty == null) { throw new InvalidOperationException(string.Format("Property {0} not found.", name)); }
                metaProperty.GetAccessor(this._Entity._ProjectedEntity).Value = value;
            }
        }
    }
}
