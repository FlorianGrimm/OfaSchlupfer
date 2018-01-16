namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SimpleCaseExpression : CaseExpression {
        private ScalarExpression _inputExpression;

        public ScalarExpression InputExpression {
            get {
                return this._inputExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._inputExpression = value;
            }
        }

        public List<SimpleWhenClause> WhenClauses { get; } = new List<SimpleWhenClause>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.InputExpression?.Accept(visitor);
            this.WhenClauses.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
