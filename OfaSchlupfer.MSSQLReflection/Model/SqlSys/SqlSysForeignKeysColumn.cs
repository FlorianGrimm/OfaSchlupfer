#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Access for sys.indexes
    /// </summary>
    public sealed class SqlSysForeignKeysColumn : EntityFlexible {
        /// <summary>
        /// SELECT ... FROM sys.foreign_key_columns;
        /// </summary>
        public const string SELECTStatement = "SELECT constraint_object_id, constraint_column_id, referenced_object_id, referenced_column_id FROM sys.foreign_key_columns;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysForeignKeysColumn"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysForeignKeysColumn(MetaEntityFlexible metaData, object[] values)
            : base(metaData, values) { }

#pragma warning disable SA1101 // Prefix local calls with this
        public int object_id { get { return this.GetPropertyAsInt(nameof(object_id)); } }

        public int index_id { get { return this.GetPropertyAsInt(nameof(index_id)); } }

        public int index_column_id { get { return this.GetPropertyAsInt(nameof(index_column_id)); } }

        public int column_id { get { return this.GetPropertyAsInt(nameof(column_id)); } }

        public int key_ordinal { get { return this.GetPropertyAsInt(nameof(key_ordinal)); } }

        public bool is_descending_key { get { return this.GetPropertyAsBool(nameof(is_descending_key)); } }

        public bool is_included_column { get { return this.GetPropertyAsBool(nameof(is_included_column)); } }

#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysForeignKeysColumn Factory(MetaEntityFlexible metaData, object[] values) {
            return new SqlSysForeignKeysColumn(metaData, values);
        }
    }
}