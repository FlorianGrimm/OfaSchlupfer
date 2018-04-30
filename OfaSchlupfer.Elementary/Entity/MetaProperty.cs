namespace OfaSchlupfer.Entity {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    /// <summary>
    /// Meta Property
    /// </summary>
    [JsonObject(ItemIsReference = true)]
    public class MetaProperty
        : FreezableObject
        , IMetaProperty {
        private IMetaEntity _MetaEntity;
        private string _Name;
        private Type _PropertyType;

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
        /// Get an bound accessor
        /// </summary>
        /// <param name="entity">the entity to access.</param>
        /// <returns>the bound accessor</returns>
        public virtual IAccessor GetAccessor(object entity) {
            throw new NotImplementedException();
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
}