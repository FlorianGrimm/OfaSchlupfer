namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.types
    /// </summary>
    public sealed class SqlSysType : EntityArrayProp, ISqlSysTypedObject {
        public const string SELECTStatement = "SELECT name, system_type_id, user_type_id, schema_id, max_length, precision, scale, collation_name, is_nullable FROM sys.types;";

        public SqlSysType(MetaEntityArrayProp metaData, object[] values) : base(metaData, values) {
        }

        public string name { get { return this.GetPropertyAsString(nameof(name)); } }
        public int column_id { get { return this.GetPropertyAsInt(nameof(column_id)); } }
        public short system_type_id { get { return this.GetPropertyAsShort(nameof(system_type_id)); } }
        public int schema_id { get { return this.GetPropertyAsInt(nameof(schema_id)); } }
        public int user_type_id { get { return this.GetPropertyAsInt(nameof(user_type_id)); } }
        public short max_length { get { return this.GetPropertyAsShort(nameof(max_length)); } }
        public byte precision { get { return this.GetPropertyAsByte(nameof(precision)); } }
        public byte scale { get { return this.GetPropertyAsByte(nameof(scale)); } }
        public string collation_name { get { return this.GetPropertyAsString(nameof(collation_name)); } }
        public bool is_nullable { get { return this.GetPropertyAsBool(nameof(is_nullable)); } }

        public static SqlSysType Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysType(metaData, values);
        }
    }
}
