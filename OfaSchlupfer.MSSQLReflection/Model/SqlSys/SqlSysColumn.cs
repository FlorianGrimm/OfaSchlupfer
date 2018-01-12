namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Elementary.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysColumn : EntityArrayProp, ISqlSysTypedObject {
        public const string SELECTStatement = @"
				SELECT c.object_id, c.name, c.column_id, c.system_type_id, c.user_type_id, c.max_length, c.precision, c.scale, c.collation_name, c.is_nullable 
                FROM sys.all_columns c 
                INNER JOIN sys.tables t 
                    ON c.object_id = t.object_id
			UNION ALL
				SELECT c.object_id, c.name, c.column_id, c.system_type_id, c.user_type_id, c.max_length, c.precision, c.scale, c.collation_name, c.is_nullable 
                FROM sys.all_columns c 
                INNER JOIN sys.views v
                    ON c.object_id = v.object_id
			;            ";
            
        public SqlSysColumn(MetaEntityArrayProp metaData, object[] values) : base(metaData, values) {
        }
        public int object_id { get { return this.GetPropertyAsInt(nameof(object_id)); } }
        public string name { get { return this.GetPropertyAsString(nameof(name)); } }
        public int column_id { get { return this.GetPropertyAsInt(nameof(column_id)); } }
        public short system_type_id { get { return this.GetPropertyAsShort(nameof(system_type_id)); } }
        public int user_type_id { get { return this.GetPropertyAsInt(nameof(user_type_id)); } }
        public short max_length { get { return this.GetPropertyAsShort(nameof(max_length)); } }
        public byte precision { get { return this.GetPropertyAsByte(nameof(precision)); } }
        public byte scale { get { return this.GetPropertyAsByte(nameof(scale)); } }
        public string collation_name { get { return this.GetPropertyAsString(nameof(collation_name)); } }
        public bool is_nullable { get { return this.GetPropertyAsBool(nameof(is_nullable)); } }

        public static SqlSysColumn Factory(MetaEntityArrayProp metaData, object[] values) {
            return new SqlSysColumn(metaData, values);
        }
    }
}
