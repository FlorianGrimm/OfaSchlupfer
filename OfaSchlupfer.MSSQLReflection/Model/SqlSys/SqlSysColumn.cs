#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysColumn : EntityArrayValues, ISqlSysTypedObject {
#if false
        public const string SELECTStatement = @"
        SELECT c.object_id, c.name, c.column_id, c.system_type_id, c.user_type_id, c.max_length, c.precision, c.scale, c.collation_name, c.is_nullable 
        FROM sys.columns c 
        INNER JOIN sys.objects t 
            ON c.object_id = t.object_id
            WHERE t.is_ms_shipped=0
        ;
        ";
#endif

        /// <summary>
        /// SELECT FROM sys.columns
        /// </summary>
        public const string SELECTStatement = @"SELECT c.object_id, c.name, c.column_id, c.system_type_id, c.user_type_id, c.max_length, c.precision, c.scale, c.collation_name, c.is_nullable FROM sys.columns c;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysColumn"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysColumn(MetaEntityArrayValues metaData, object[] values)
            : base(metaData, values) { }

#pragma warning disable SA1101 // Prefix local calls with this
        /// <summary>
        /// Gets the object_id related object
        /// </summary>
        public int object_id { get { return this.GetPropertyAsInt(nameof(object_id)); } }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string name { get { return this.GetPropertyAsString(nameof(name)); } }

        /// <summary>
        /// Gets the column_id
        /// </summary>
        public int column_id { get { return this.GetPropertyAsInt(nameof(column_id)); } }

        /// <summary>
        /// Gets the system_type_id
        /// </summary>
        public short system_type_id { get { return this.GetPropertyAsShort(nameof(system_type_id)); } }

        /// <summary>
        /// Gets the user_type_id
        /// </summary>
        public int user_type_id { get { return this.GetPropertyAsInt(nameof(user_type_id)); } }

        /// <summary>
        /// Gets the max_length        /// </summary>
        public short max_length { get { return this.GetPropertyAsShort(nameof(max_length)); } }

        /// <summary>
        /// Gets the precision
        /// </summary>
        public byte precision { get { return this.GetPropertyAsByte(nameof(precision)); } }

        /// <summary>
        /// Gets the scale
        /// </summary>
        public byte scale { get { return this.GetPropertyAsByte(nameof(scale)); } }

        /// <summary>
        /// Gets the collation_name
        /// </summary>
        public string collation_name { get { return this.GetPropertyAsString(nameof(collation_name)); } }

        /// <summary>
        /// Gets a value indicating whether gets the type is nullable.
        /// </summary>
        public bool is_nullable { get { return this.GetPropertyAsBool(nameof(is_nullable)); } }
#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysColumn Factory(MetaEntityArrayValues metaData, object[] values) {
            return new SqlSysColumn(metaData, values);
        }
    }
}
