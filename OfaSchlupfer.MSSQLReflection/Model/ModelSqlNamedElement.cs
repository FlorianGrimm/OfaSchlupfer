namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// a element with an name
    /// </summary>
    public sealed class ModelSqlNamedElement {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlNamedElement"/> class.
        /// </summary>
        public ModelSqlNamedElement() { }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public SqlName Name { get; set; }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        public ModelSqlElementType Type { get; set; }
    }
}
