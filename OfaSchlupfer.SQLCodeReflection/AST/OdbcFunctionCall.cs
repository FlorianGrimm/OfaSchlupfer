namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class OdbcFunctionCall : PrimaryExpression {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public bool ParametersUsed { get; set; }

        public List<ScalarExpression> Parameters { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
            this.Parameters.Accept(visitor);
        }
    }
}
