namespace OfaSchlupfer.Entity {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject(ItemIsReference = true)]
    public class MetaPropertyFlexible
       : FreezeableObject
       , IMetaIndexedProperty {
        private IMetaEntity _MetaEntity;
        private string _Name;
        private int _Index;
        private Type _PropertyType;

        public MetaPropertyFlexible() {
        }

        public MetaPropertyFlexible(int index, string name, Type propertyType) {
            this._Name = name;
            this._PropertyType = propertyType;
            this._Index = index;
        }

        public IMetaEntity MetaEntity {
            get => this._MetaEntity;
            set => this.SetRefPropertyOnce(ref this._MetaEntity, value);
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name {
            get => this._Name;
            set => this.SetStringProperty(ref this._Name, value);
        }

        public Type PropertyType {
            get => this._PropertyType;
            set => this.SetRefProperty(ref this._PropertyType, value);
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        public int Index {
            get => this._Index;
            set => this.SetValueProperty(ref this._Index, value);
        }

        public IAccessor GetAccessor(object entity)=> new AccessorFlexible(this, (IEntityFlexible) entity);

        /// <summary>
        /// validate the type of value.
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="validateOrThrow">false - return a message or true - throw an exception.</param>
        /// <returns>an error message or null.</returns>
        public virtual string Validate(object value, bool validateOrThrow) {
            if ((object)this._PropertyType != null) {
                if (value is null) {
                    if (this._PropertyType.IsValueType && (Nullable.GetUnderlyingType(this._PropertyType) is null)) {
                        var msg = $"${this.Name} is not nullable.";
                        if (validateOrThrow) {
                            return msg;
                        } else {
                            throw new InvalidOperationException(msg);
                        }
                    }
                } else {
                    var valueType = value.GetType();
                    if (!this._PropertyType.IsAssignableFrom(valueType)) {
                        var msg = $"Value- ${valueType.FullName} for ${this.Name}-${this._PropertyType.FullName} is not type compatible.";
                        if (validateOrThrow) {
                            return msg;
                        } else {
                            throw new InvalidOperationException(msg);
                        }
                    }
                }
            }
            return null;
        }

    }

    /// <summary>
    /// MetaProperty for EntityFlexible
    /// </summary>
    [JsonObject(ItemIsReference = true)]
    public class MetaPropertyFlexibleChained
        : FreezeableObject
        , IMetaIndexedProperty {

        private IMetaEntity _MetaEntity;
        private int _Index;
        private readonly IMetaProperty _ChainedMetaProperty;
        public MetaPropertyFlexibleChained(int index, IMetaProperty chainedMetaProperty) {
            if (chainedMetaProperty is null) { throw new ArgumentNullException(nameof(chainedMetaProperty)); }
            this._Index = index;
            this._ChainedMetaProperty = chainedMetaProperty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropertyFlexible"/> class.
        /// </summary>
        /// <param name="index">the index</param>
        /// <param name="name">the name</param>
        /// <param name="propertyType">the propertyType</param>
        public MetaPropertyFlexibleChained(int index, string name, Type propertyType) {
            this._Index = index;
            this._ChainedMetaProperty = new MetaProperty() { Name = name, PropertyType = propertyType };
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        public int Index {
            get => this._Index;
            set => this.SetValueProperty(ref this._Index, value);
        }

        public IMetaEntity MetaEntity {
            get {
                return this._MetaEntity;
            }
            set {
                if (ReferenceEquals(this._MetaEntity, value)) { return; }
                if ((object)this._MetaEntity != null) {
                    this.ThrowIfFrozen();
                    throw new ArgumentException("Cannot be set again");
                }
                this._MetaEntity = value;
#warning thinkofagain
                if (this._ChainedMetaProperty != null) {
                    if (this._ChainedMetaProperty.MetaEntity is null) {
                        this._ChainedMetaProperty.MetaEntity = value;
                    }
                }
            }
        }

        public string Name => this._ChainedMetaProperty.Name;

        public Type PropertyType { get { return this._ChainedMetaProperty.PropertyType; } set { this._ChainedMetaProperty.PropertyType = value; } }

        /// <summary>
        /// get the accessor for this property in this entity.
        /// </summary>
        /// <param name="entity">the entity</param>
        /// <returns>the accessor.</returns>
        public IAccessor GetAccessor(object entity) => new AccessorFlexible(this, (IEntityFlexible)entity);

        /// <summary>
        /// validate the type of value.
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="validateOrThrow">false - return a message or true - throw an exception.</param>
        /// <returns>an error message or null.</returns>
        public virtual string Validate(object value, bool validateOrThrow) => this._ChainedMetaProperty.Validate(value, validateOrThrow);
    }
}