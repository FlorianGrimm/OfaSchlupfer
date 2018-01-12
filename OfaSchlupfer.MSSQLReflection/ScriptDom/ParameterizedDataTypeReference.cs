using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ParameterizedDataTypeReference : DataTypeReference {
        private List<Literal> _parameters = new List<Literal>();

        public List<Literal> Parameters {
            get {
                return this._parameters;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
        }
    }
}
