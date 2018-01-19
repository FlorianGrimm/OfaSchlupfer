namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class ModelSqlScalarValue {
        
        public ModelSqlScalarType Type { get; set; }
        public object Value { get; set; }
        public bool IsConst { get; set; }
    }
}
