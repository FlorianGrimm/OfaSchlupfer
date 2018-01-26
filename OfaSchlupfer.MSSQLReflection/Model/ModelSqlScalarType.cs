namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// the scalar type of sql
    /// </summary>
    public sealed class ModelSqlScalarType {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlScalarType"/> class.
        /// </summary>
        public ModelSqlScalarType() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlScalarType"/> class.
        /// </summary>
        /// <param name="src">the source</param>
        public ModelSqlScalarType(ModelSqlScalarType src) {
            if ((object)src != null) {
                this.TypeName = src.TypeName;
                this.MaxLength = src.MaxLength;
                this.Scale = src.Scale;
                this.Precision = src.Precision;
                this.CollationName = src.CollationName;
                this.IsNullable = src.IsNullable;
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public SqlName TypeName { get; set; }

        /// <summary>
        /// Gets or sets the MaxLength.
        /// </summary>
        public short MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the Precision.
        /// </summary>
        public byte Precision { get; set; }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        public byte Scale { get; set; }

        /// <summary>
        /// Gets or sets the CollationName.
        /// </summary>
        public string CollationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is nullable.
        /// </summary>
        public bool IsNullable { get; set; }
    }
}
