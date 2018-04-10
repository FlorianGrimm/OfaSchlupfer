namespace OfaSchlupfer.Entitiy {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// MetaData for EntityArrayProp
    /// </summary>
    public class MetaEntityArrayValues : IMetaEntity {
        private List<MetaPropertyArrayValues> _PropertyByIndex;
        private Dictionary<string, MetaPropertyArrayValues> _PropertyByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityArrayValues"/> class.
        /// </summary>
        public MetaEntityArrayValues() {
            this._PropertyByIndex = new List<MetaPropertyArrayValues>();
            this._PropertyByName = new Dictionary<string, MetaPropertyArrayValues>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityArrayValues"/> class.
        /// </summary>
        /// <param name="names">names of properties.</param>
        public MetaEntityArrayValues(IEnumerable<string> names)
            : this() {
            if (names != null) {
                int idx = 0;
                foreach (var name in names) {
                    this.AddProperty(new MetaPropertyArrayValues(name, idx));
                    idx++;
                }
            }
        }

        /// <summary>
        /// Gets the property by index.
        /// </summary>
        public List<MetaPropertyArrayValues> PropertyByIndex { get { return this._PropertyByIndex; } }

        /// <summary>
        /// Gets the property by name.
        /// </summary>
        public Dictionary<string, MetaPropertyArrayValues> PropertyByName { get { return this._PropertyByName; } }

        /// <summary>
        /// Add a MetaProperty
        /// </summary>
        /// <param name="metaProperty">the property to add.</param>
        public void AddProperty(MetaPropertyArrayValues metaProperty) {
            if (metaProperty == null) { throw new ArgumentNullException(nameof(metaProperty)); }

            // check if property exists
            if (this._PropertyByName.ContainsKey(metaProperty.Name)) {
                throw new ArgumentException("Property already exists.");
            }

            // and add
            if (metaProperty.Index < 0) {
                metaProperty.Index = this._PropertyByIndex.Count;
                this._PropertyByIndex.Add(metaProperty);
                this._PropertyByName.Add(metaProperty.Name, metaProperty);
            } else if (this._PropertyByIndex.Count == metaProperty.Index) {
                this._PropertyByIndex.Add(metaProperty);
                this._PropertyByName.Add(metaProperty.Name, metaProperty);
            } else {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Get the named property
        /// </summary>
        /// <param name="name">the name of the property</param>
        /// <returns>the property or null</returns>
        public IMetaProperty GetProperty(string name) {
            if (name == null) { throw new ArgumentNullException(nameof(name)); }
            MetaPropertyArrayValues result = null;
            if (this._PropertyByName.TryGetValue(name, out result)) {
                return result;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Get all properties.
        /// </summary>
        /// <returns>a list of properties.</returns>
        public IEnumerable<IMetaProperty> GetProperties() {
            return this.PropertyByName.Values.Cast<IMetaProperty>().ToArray();
        }

        /*
        public IMetaProperty<TData> GetPropertyT<TData>(string name) {
            throw new NotImplementedException();
        }
        */
    }
}
