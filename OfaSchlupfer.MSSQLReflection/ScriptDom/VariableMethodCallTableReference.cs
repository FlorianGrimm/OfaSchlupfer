using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class VariableMethodCallTableReference : TableReferenceWithAliasAndColumns {
        private VariableReference _variable;

        private Identifier _methodName;

        private List<ScalarExpression> _parameters = new List<ScalarExpression>();

        public VariableReference Variable {
            get {
                return this._variable;
            }
            set {
                base.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public Identifier MethodName {
            get {
                return this._methodName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._methodName = value;
            }
        }

        public List<ScalarExpression> Parameters {
            get {
                return this._parameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.MethodName?.Accept(visitor);
            for (int i=0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
