﻿namespace OfaSchlupfer.SqlAccess {
    /// <summary>
    /// the accessor to the value.
    /// </summary>
    public struct AccessorArrayProp : IAccessor {
        private EntityArrayProp _Entity;
        private MetaPropertyArrayProp _MetaProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessorArrayProp"/> struct.
        /// </summary>
        /// <param name="metaPropertyArrayProp">the property</param>
        /// <param name="entity">the entity</param>
        public AccessorArrayProp(MetaPropertyArrayProp metaPropertyArrayProp, object entity) {
            this._MetaProperty = metaPropertyArrayProp;
            this._Entity = (EntityArrayProp)entity;
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
                return this._Entity.Values[this._MetaProperty.Index];
            }

            set {
                this._Entity.Values[this._MetaProperty.Index] = value;
            }
        }
    }
}