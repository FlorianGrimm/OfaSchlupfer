using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BuiltInFunctionTableReference : TableReferenceWithAlias {
        private Identifier _name;

        private List<ScalarExpression> _parameters = new List<ScalarExpression>();

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ScalarExpression> Parameters {
            get {
                return this._parameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
            for (int i=0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
        }
    }
}
