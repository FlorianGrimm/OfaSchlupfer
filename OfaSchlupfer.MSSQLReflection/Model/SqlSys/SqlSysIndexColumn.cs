#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System.Collections.Generic;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Access for sys.indexes
    /// </summary>
    public sealed class SqlSysIndexColumn : EntityArrayValues {
        /// <summary>
        /// SELECT ... FROM sys.indexes i;
        /// </summary>
        public const string SELECTStatement = "SELECT c.object_id, c.index_id, c.index_column_id, c.column_id, c.key_ordinal, c.is_descending_key, c.is_included_column FROM sys.index_columns c INNER JOIN sys.indexes i ON c.object_id = i.object_id INNER JOIN sys.tables t ON i.object_id = t.object_id;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysIndexColumn"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysIndexColumn(MetaEntityArrayValues metaData, object[] values)
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
        public static SqlSysIndexColumn Factory(MetaEntityArrayValues metaData, object[] values) {
            return new SqlSysIndexColumn(metaData, values);
        }
    }
}