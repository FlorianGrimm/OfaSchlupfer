using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PartitionFunctionCall : PrimaryExpression {
        private Identifier _databaseName;

        private Identifier _functionName;

        private List<ScalarExpression> _parameters = new List<ScalarExpression>();

        public Identifier DatabaseName {
            get {
                return this._databaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public Identifier FunctionName {
            get {
                return this._functionName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._functionName = value;
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
            this.DatabaseName?.Accept(visitor);
            this.FunctionName?.Accept(visitor);
            for (int i=0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
        }
    }
}
