namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A scalar value
    /// </summary>
    public sealed class ModelSqlScalarValue {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlScalarValue"/> class.
        /// </summary>
        public ModelSqlScalarValue() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlScalarValue"/> class.
        /// </summary>
        /// <param name="type">the type</param>
        /// <param name="value">the value</param>
        /// <param name="isConst">const</param>
        public ModelSqlScalarValue(ModelSqlScalarType type, object value, bool isConst) {
            this.Type = type;
            this.Value = value;
            this.IsConst = isConst;
        }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        public ModelSqlScalarType Type { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is constant.
        /// </summary>
        public bool IsConst { get; set; }
    }
}
