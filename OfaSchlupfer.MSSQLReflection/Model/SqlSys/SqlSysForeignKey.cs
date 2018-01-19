#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System.Collections.Generic;
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.indexes SqlSysForeignKeys
    /// </summary>
    public sealed class SqlSysForeignKey : EntityArrayProp {
        /// <summary>
        /// SELECT ... FROM sys.foreign_keys;
        /// </summary>
        public const string SELECTStatement = "SELECT name, object_id, schema_id, type, create_date, modify_date, referenced_object_id, key_index_id, delete_referential_action_desc, update_referential_action_desc, is_system_named FROM sys.foreign_keys;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysForeignKey"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysForeignKey(MetaEntityArrayProp metaData, object[] values)
            : base(metaData, values) {
            this.ForeignKeysColumns = new List<SqlSysForeignKeysColumn>();
        }

        /// <summary>
        /// Gets the IndexColumns.
        /// </summary>
        public List<SqlSysForeignKeysColumn> ForeignKeysColumns { get; }

#pragma warning disable SA1101 // Prefix local calls with this
        public int object_id { get { return this.GetPropertyAsInt(nameof(object_id)); } }

        public string name { get { return this.GetPropertyAsString(nameof(name)); } }

        public int index_id { get { return this.GetPropertyAsInt(nameof(index_id)); } }

        public string type_desc { get { return this.GetPropertyAsString(nameof(type_desc)); } }

        public bool is_unique { get { return this.GetPropertyAsBool(nameof(is_unique)); } }

        public bool is_primary_key { get { return this.GetPropertyAsBool(nameof(is_primary_key)); } }

        public bool is_unique_constraint { get { return this.GetPropertyAsBool(nameof(is_unique_constraint)); } }

        public string filter_definition { get { return this.GetPropertyAsString(nameof(filter_definition)); } }

#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysForeignKey Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysForeignKey(metaData, values);
        }
    }
}