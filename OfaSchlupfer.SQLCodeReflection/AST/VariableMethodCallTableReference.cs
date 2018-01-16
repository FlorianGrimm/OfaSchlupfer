namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class VariableMethodCallTableReference : TableReferenceWithAliasAndColumns {
        private VariableReference _variable;

        private Identifier _methodName;

        public VariableReference Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public Identifier MethodName {
            get {
                return this._methodName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._methodName = value;
            }
        }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            this.MethodName?.Accept(visitor);
            this.Parameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
