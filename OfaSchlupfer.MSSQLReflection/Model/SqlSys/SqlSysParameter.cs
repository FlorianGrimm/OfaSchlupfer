#pragma warning disable SA1600

namespace OfaSchlupfer.MSSQLReflection.Model.SqlSys {
    using OfaSchlupfer.Entitiy;
    using OfaSchlupfer.SqlAccess;

    /// <summary>
    /// Access for sys.schema
    /// </summary>
    public sealed class SqlSysParameter : EntityArrayValues, ISqlSysTypedObject {
        public const string SELECTStatement = "SELECT object_id, name, parameter_id, system_type_id, user_type_id , max_length, precision, scale ,is_output, has_default_value, default_value, is_nullable FROM sys.parameters;";

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlSysParameter"/> class.
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        public SqlSysParameter(MetaEntityArrayValues metaData, object[] values)
            : base(metaData, values) { }

#pragma warning disable SA1101 // Prefix local calls with this
        public int object_id { get { return this.GetPropertyAsInt(nameof(object_id)); } }

        public string name { get { return this.GetPropertyAsString(nameof(name)); } }

        public int parameter_id { get { return this.GetPropertyAsInt(nameof(parameter_id)); } }

        public short system_type_id { get { return this.GetPropertyAsShort(nameof(system_type_id)); } }

        public int user_type_id { get { return this.GetPropertyAsInt(nameof(user_type_id)); } }

        public short max_length { get { return this.GetPropertyAsShort(nameof(max_length)); } }

        public byte precision { get { return this.GetPropertyAsByte(nameof(precision)); } }

        public byte scale { get { return this.GetPropertyAsByte(nameof(scale)); } }

        public string collation_name { get { return null; } }

        public bool is_nullable { get { return this.GetPropertyAsBool(nameof(is_nullable)); } }

        public bool is_output { get { return this.GetPropertyAsBool(nameof(is_output)); } }

        public bool has_default_value { get { return this.GetPropertyAsBool(nameof(has_default_value)); } }

        public string default_value { get { return this.GetPropertyAsString(nameof(default_value)); } }
#pragma warning restore SA1101 // Prefix local calls with this

        /// <summary>
        /// Factory function
        /// </summary>
        /// <param name="metaData">the metadata</param>
        /// <param name="values">the values</param>
        /// <returns>a new instance</returns>
        public static SqlSysParameter Factory(MetaEntityArrayValues metaData, object[] values) {
            return new SqlSysParameter(metaData, values);
        }
    }
}