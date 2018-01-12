namespace OfaSchlupfer.Elementary.SqlAccess {
    using System.Collections.Generic;

    /// <summary>
    /// the type specification.
    /// </summary>
    public interface IMetaEntity {
        /// <summary>
        /// Gets the unbound accessor to the named property name
        /// </summary>
        /// <param name="name">the property names</param>
        /// <returns>an unbound accessor</returns>
        IMetaProperty GetProperty(string name);

        /// <summary>
        /// Get all properties.
        /// </summary>
        /// <returns>a list of properties.</returns>
        IEnumerable<IMetaProperty> GetProperties();
    }
}