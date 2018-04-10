namespace OfaSchlupfer.Entitiy {
    using System;

    /// <summary>
    /// Meta Property
    /// </summary>
    public class MetaProperty : IMetaProperty {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get an bound accessor
        /// </summary>
        /// <param name="entity">the entity to access.</param>
        /// <returns>the bound accessor</returns>
        public virtual IAccessor GetAccessor(object entity) {
            throw new NotImplementedException();
        }
    }
}