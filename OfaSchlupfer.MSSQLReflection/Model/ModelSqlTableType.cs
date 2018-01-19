namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// the type of an table like element
    /// </summary>
    public sealed class ModelSqlTableType
        : ModelSqlElementType {
        private readonly List<ModelSqlNamedElement> _Columns;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSqlTableType"/> class.
        /// </summary>
        public ModelSqlTableType() {
            this._Columns = new List<ModelSqlNamedElement>();
        }

        /// <summary>
        /// Gets the Columns
        /// </summary>
        public List<ModelSqlNamedElement> Columns => this._Columns;
    }
}
