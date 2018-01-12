namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysSchema : EntityArrayProp {
        public const string SELECTStatement = "SELECT name, schema_id FROM sys.schemas;";
        public SqlSysSchema(MetaEntityArrayProp metaData, object[] values) : base(metaData, values) {
        }
        public string name { get { return this.GetPropertyAsString(nameof(name));} }
        public int schema_id { get { return this.GetPropertyAsInt(nameof(schema_id));} }
        public static SqlSysSchema Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysSchema(metaData, values);
        }
    }
}
