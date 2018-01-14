namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysSchema : EntityArrayProp {
        /// <summary>
        /// SQL Statemant SELECT name, schema_id FROM sys.schemas;
        /// </summary>
        public const string SELECTStatement = "SELECT name, schema_id FROM sys.schemas;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysSchema"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysSchema(MetaEntityArrayProp metaData, object[] values)
            : base(metaData, values) {
        }

#pragma warning disable SA1101 // Prefix local calls with this

        /// <summary>
        /// Gets the schema name.
        /// </summary>
        public string name { get { return this.GetPropertyAsString(nameof(name)); } }

        /// <summary>
        /// Gets the schema id.
        /// </summary>
        public int schema_id { get { return this.GetPropertyAsInt(nameof(schema_id)); } }

#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysSchema Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysSchema(metaData, values);
        }
    }
}
