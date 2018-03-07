namespace OfaSchlupfer.SqlAccess {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// metadata for projection
    /// </summary>
    public class MetaEntityProjection : IMetaEntity {
        private Dictionary<string, MetaPropertyProjection> _PropertyByName;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityProjection"/> class.
        /// </summary>
        public MetaEntityProjection() {
            this._PropertyByName = new Dictionary<string, MetaPropertyProjection>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaEntityProjection"/> class.
        /// </summary>
        /// <param name="names">think of</param>
        public MetaEntityProjection(IEnumerable<string> names)
            : this() {
            if (names != null) {
                foreach (var name in names) {
                    this.AddProperty(new MetaPropertyProjection(name, name));
                }
            }
        }

        /// <summary>
        /// Add a MetaProperty
        /// </summary>
        /// <param name="metaProperty">the property to add.</param>
        public void AddProperty(MetaPropertyProjection metaProperty) {
            if (metaProperty == null) { throw new ArgumentNullException(nameof(metaProperty)); }

            // check if property exists.
            if (this._PropertyByName.ContainsKey(metaProperty.Name)) {
                throw new ArgumentException("Property already exists.");
            }
            this._PropertyByName.Add(metaProperty.Name, metaProperty);
        }

        /// <summary>
        /// Gets the property by name.
        /// </summary>
        public Dictionary<string, MetaPropertyProjection> PropertyByName { get { return this._PropertyByName; } }

        /// <summary>
        /// Gets the unbound accessor to the named property name
        /// </summary>
        /// <param name="name">the property names</param>
        /// <returns>an unbound accessor or null</returns>
        public IMetaProperty GetProperty(string name) {
            if (name == null) { throw new ArgumentNullException(nameof(name)); }
            MetaPropertyProjection result = null;
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
    }
}
