namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A scalar value
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Type}-{Value}")]
    public sealed class ModelSematicValueScalar {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSematicValueScalar"/> class.
        /// </summary>
        public ModelSematicValueScalar() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSematicValueScalar"/> class.
        /// </summary>
        /// <param name="type">the type</param>
        /// <param name="value">the value</param>
        /// <param name="isConst">const</param>
        public ModelSematicValueScalar(ModelSematicScalarType type, object value, bool isConst) {
            this.Type = type;
            this.Value = value;
            this.IsConst = isConst;
        }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        public ModelSematicScalarType Type { get; set; }

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
