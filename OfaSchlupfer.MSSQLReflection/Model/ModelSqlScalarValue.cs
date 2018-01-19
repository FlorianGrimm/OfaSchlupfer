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
