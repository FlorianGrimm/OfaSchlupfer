namespace OfaSchlupfer.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Freezable;

    [JsonObject]
    public class ModelProperty
        : ModelNamedOwnedElement<ModelComplexType> {
        [JsonIgnore]
        private ModelType _Type;

        public ModelProperty() { }

        [JsonIgnore]
        public override ModelComplexType Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Properties);
        }

        [JsonProperty]
        public ModelType Type {
            get {
                return this._Type;
            }
            set {
                this.ThrowIfFrozen();
                this._Type = value;
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this.Type?.Freeze();
            }
            return result;
        }

        public IMetaIndexedProperty GetMetaProperty(int index) => new ModelPropertyMetaProperty(this, index);

        public Type GetClrType() => this.Type.GetClrType();
    }

    public class ModelPropertyMetaProperty
        : FreezableObject
        , IMetaProperty
        , IMetaIndexedProperty {
        private IMetaEntity _MetaEntity;
        private string _Name;
        private Type _PropertyType;
        private int _Index;

        public ModelPropertyMetaProperty(ModelProperty modelProperty, int index) {
            this._Name = modelProperty.Name;
            this._PropertyType = modelProperty.GetClrType();
            this._Index = index;
            if (modelProperty.IsFrozen()) {
                this.Freeze();
            }
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

        /// <summary>
        /// Get an bound accessor
        /// </summary>
        /// <param name="entity">the entity to access.</param>
        /// <returns>the bound accessor</returns>
        public virtual IAccessor GetAccessor(object entity) {
            return new AccessorFlexible(this, (IEntityFlexible)entity);
        }


        /// <summary>
        /// validate the type of value.
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="validateOrThrow">false - return a message or true - throw an exception.</param>
        /// <returns>an error message or null.</returns>
        public virtual string Validate(object value, bool validateOrThrow) {
            if ((object)this._PropertyType != null) {
                if (value is null) {
                    if (this._PropertyType.IsValueType && (Nullable.GetUnderlyingType(this._PropertyType) == null)) {
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
}
