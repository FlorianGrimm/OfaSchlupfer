namespace OfaSchlupfer.MSSQLReflection.Model {
    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// base we will see
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{TypeName}")]
    public class ModelSematicType
        : FreezableObject {
        private SqlName _Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSematicType"/> class.
        /// </summary>
        public ModelSematicType() { }

        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>the name or null</returns>
        public virtual string GetName() { return null; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        //[JsonProperty(ItemConverterType = typeof(SqlNameJsonConverter))]
        [JsonIgnore]
        public virtual SqlName Name { get => this._Name; set => this.SetOrThrowIfFrozen(ref this._Name, value); }

        [JsonProperty]
        public string NameSql { get { return SqlNameJsonConverter.ConvertToValue(this.Name); } set { this.ThrowIfFrozen(); this.Name = SqlNameJsonConverter.ConvertFromValue(value); } }


        /// <summary>
        /// Convert a <see cref="ModelSqlType"/> to a ModelSystemDataType
        /// </summary>
        /// <param name="modelSqlType">the instance to convert.</param>
        //public static explicit operator ModelSematicType(ModelSqlType modelSqlType) {
        public static ModelSematicType Create(ModelSqlType modelSqlType) {
            if (modelSqlType == null) { return null; }
            ModelSystemDataType dataType = ModelSystemDataType.None;
            if (!(modelSqlType.BaseOnType is null)) {
                dataType = ModelSystemDataTypeUtility.ConvertFromSqlName(modelSqlType.BaseOnType.Name);
            } else {
                dataType = ModelSystemDataTypeUtility.ConvertFromSqlName(modelSqlType.Name);
            }

            return new ModelSematicScalarType() {
                Name = modelSqlType.Name,
                SystemDataType = dataType,
                CollationName = modelSqlType.CollationName,
                IsNullable = modelSqlType.Nullable,
                MaxLength = modelSqlType.MaxLength,
                Precision = modelSqlType.Precision,
                Scale = modelSqlType.Scale
            };
        }
    }
}