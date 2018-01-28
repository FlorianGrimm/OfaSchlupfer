namespace OfaSchlupfer.MSSQLReflection.Model {
    /// <summary>
    /// base we will see
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{TypeName}")]
    public class ModelType {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelType"/> class.
        /// </summary>
        public ModelType() { }

        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>the name or null</returns>
        public virtual string GetName() { return null; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public virtual SqlName TypeName { get; set; }

        /// <summary>
        /// Convert a <see cref="ModelSqlType"/> to a ModelSystemDataType
        /// </summary>
        /// <param name="modelSqlType">the instance to convert.</param>
        public static explicit operator ModelType(ModelSqlType modelSqlType) {
            if (modelSqlType == null) { return null; }
            ModelSystemDataType dataType = ModelSystemDataType.None;

            // TODO: Convert name to dataType
            return new ModelTypeScalar() {
                TypeName = modelSqlType.Name,
                SystemDataType = dataType,
                CollationName = modelSqlType.CollationName,
                IsNullable = modelSqlType.IsNullable,
                MaxLength = modelSqlType.MaxLength,
                Precision = modelSqlType.Precision,
                Scale = modelSqlType.Scale
            };
        }
    }
}