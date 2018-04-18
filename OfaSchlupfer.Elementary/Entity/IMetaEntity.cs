namespace OfaSchlupfer.Entity {
    using System.Collections.Generic;

    /// <summary>
    /// the type specification.
    /// </summary>
    public interface IMetaEntity {
        /// <summary>
        /// Gets or sets the typename.
        /// </summary>
        string EntityTypeName { get; set; }

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
        IList<IMetaProperty> GetProperties();

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="metaProperty">property</param>
        /// <param name="values"></param>
        /// <param name="validateOrThrow"></param>
        /// <returns></returns>
        string Validate(IMetaProperty metaProperty, object value, bool validateOrThrow);
    }

    public interface IMetaEntityArrayValues : IMetaEntity {
        /// <summary>
        /// Gets the property by index.
        /// </summary>
        IMetaIndexedProperty GetPropertyByIndex(int index);

        /// <summary>
        /// Gets the properties sorted by index.
        /// </summary>
        IList<IMetaIndexedProperty> GetPropertiesByIndex();

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="values"></param>
        /// <param name="validateOrThrow"></param>
        /// <returns></returns>
        string Validate(object[] values, bool validateOrThrow);
    }
}