#if weichei
namespace OfaSchlupfer.Entitiy {
    using System;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// MetaProperty for EntityArrayProp
    /// </summary>
    public class MetaPropertyArrayValues : MetaProperty {
        private int _Index;
        /// <summary>
        /// Gets or sets the index
        /// </summary>
        public int Index {
            get { return this._Index; }
            set {
                this.ThrowIfFrozen();
                this._Index = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropertyArrayValues"/> class.
        /// </summary>
        /// <param name="name">the name</param>
        /// <param name="idx">the index</param>
        /// <param name="propertyType">the propertyType</param>
        public MetaPropertyArrayValues(string name, int idx, Type propertyType) {
            this.Name = name;
            this._Index = idx;
            this.PropertyType = propertyType;
        }

        /// <summary>
        /// get the accessor for this property in this entity.
        /// </summary>
        /// <param name="entity">the entity</param>
        /// <returns>the accessor.</returns>
        public override IAccessor GetAccessor(object entity) {
            return new AccessorArrayValues(this, entity);
        }
    }
}
#endif


namespace OfaSchlupfer.Entitiy {
    using System;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// MetaProperty for EntityArrayProp
    /// </summary>
    public class MetaPropertyArrayValues
        : FreezeableObject
        , IMetaIndexedProperty {

        private int _Index;
        private readonly IMetaProperty _ChainedMetaProperty;

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        public int Index {
            get { return this._Index; }
            set {
                this.ThrowIfFrozen();
                this._Index = value;
            }
        }

        public string Name => this._ChainedMetaProperty.Name;

        public MetaPropertyArrayValues(int index, IMetaProperty chainedMetaProperty) {
            if ((object)chainedMetaProperty == null) { throw new ArgumentNullException(nameof(chainedMetaProperty)); }
            this._Index = index;
            this._ChainedMetaProperty = chainedMetaProperty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropertyArrayValues"/> class.
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="name">the name</param>
        /// <param name="propertyType">the propertyType</param>
        public MetaPropertyArrayValues(int index, string name, Type propertyType) {
            this._Index = index;
            this._ChainedMetaProperty = new MetaProperty() { Name = name, PropertyType = propertyType };
        }

        /// <summary>
        /// get the accessor for this property in this entity.
        /// </summary>
        /// <param name="entity">the entity</param>
        /// <returns>the accessor.</returns>
        public IAccessor GetAccessor(object entity) {
            return new AccessorArrayValues(this, entity);
        }

        /// <summary>
        /// validate the type of value.
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="validateOrThrow">false - return a message or true - throw an exception.</param>
        /// <returns>an error message or null.</returns>
        public virtual string Validate(object value, bool validateOrThrow) => this._ChainedMetaProperty.Validate(value, validateOrThrow);
    }
}