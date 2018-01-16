namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class PartitionFunctionCall : PrimaryExpression {
        private Identifier _databaseName;

        private Identifier _functionName;

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

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DatabaseName?.Accept(visitor);
            this.FunctionName?.Accept(visitor);
            this.Parameters.Accept(visitor);
        }
    }
}
