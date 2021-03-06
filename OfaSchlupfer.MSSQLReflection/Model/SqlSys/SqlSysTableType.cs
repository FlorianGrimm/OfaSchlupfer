﻿#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Access for sys.types
    /// </summary>
    public sealed class SqlSysTableType : EntityFlexible/*, ISqlSysTableTypedObject*/ {
        /// <summary>
        /// SELECT  FROM sys.types;
        /// </summary>
        public const string SELECTStatement = "SELECT name, system_type_id, user_type_id, schema_id, max_length, precision, scale, collation_name, is_nullable FROM sys.types;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysTableType"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysTableType(MetaEntityFlexible metaData, object[] values)
            : base(metaData, values) { }

#pragma warning disable SA1101 // Prefix local calls with this
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
#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysTableType Factory(MetaEntityFlexible metaData, object[] values) {
            return new SqlSysTableType(metaData, values);
        }
    }
}
