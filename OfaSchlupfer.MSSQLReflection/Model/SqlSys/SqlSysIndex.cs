#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using System.Collections.Generic;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Access for sys.indexes SqlSysForeignKeys
    /// </summary>
    public sealed class SqlSysIndex : EntityFlexible {
        /// <summary>
        /// SELECT ... FROM sys.indexes i;
        /// </summary>
        public const string SELECTStatement = "SELECT i.name, i.object_id, i.index_id, i.type_desc, i.is_unique, i.is_primary_key, i.is_unique_constraint, i.filter_definition FROM sys.indexes i INNER JOIN sys.objects t ON i.object_id = t.object_id WHERE (t.schema_id!=4);";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysIndex"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysIndex(MetaEntityFlexible metaData, object[] values)
            : base(metaData, values) {
            this.IndexColumns = new List<SqlSysIndexColumn>();
        }

        /// <summary>
        /// Gets the IndexColumns.
        /// </summary>
        public List<SqlSysIndexColumn> IndexColumns { get; }

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
        public static SqlSysIndex Factory(MetaEntityFlexible metaData, object[] values) {
            return new SqlSysIndex(metaData, values);
        }
    }
}