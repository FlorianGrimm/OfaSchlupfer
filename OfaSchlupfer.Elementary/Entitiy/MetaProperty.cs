namespace OfaSchlupfer.Entitiy {
    using System;
    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Meta Property
    /// </summary>
    public class MetaProperty
        : FreezeableObject
        , IMetaProperty {
        private string _Name;
        private Type _Type;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name {
            get { return this._Name; }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        public Type PropertyType {
            get { return this._Type; }
            set {
                this.ThrowIfFrozen();
                this._Type = value;
            }
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
            if ((object)this._Type != null) {
                if ((object)value == null) {
                    if (this._Type.IsValueType && (Nullable.GetUnderlyingType(this._Type) == null)) {
                        var msg = $"${this.Name} is not nullable.";
                        if (validateOrThrow) {
                            return msg;
                        } else {
                            throw new InvalidOperationException(msg);
                        }
                    }
                } else {
                    var valueType = value.GetType();
                    if (!this._Type.IsAssignableFrom(valueType)) {
                        var msg = $"Value- ${valueType.FullName} for ${this.Name}-${this._Type.FullName} is not type compatible.";
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