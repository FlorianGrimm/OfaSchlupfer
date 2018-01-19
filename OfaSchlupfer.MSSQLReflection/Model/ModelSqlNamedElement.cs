namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class ModelSqlNamedElement {
        public ModelSqlNamedElement() {
        }

        public SqlName Name { get; set; }

        public ModelSqlScalarType Type { get; set; }
    }
}
