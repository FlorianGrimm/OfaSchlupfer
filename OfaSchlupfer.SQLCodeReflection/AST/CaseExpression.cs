namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class CaseExpression : PrimaryExpression {
        private ScalarExpression _elseExpression;

        public ScalarExpression ElseExpression {
            get {
                return this._elseExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._elseExpression = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ElseExpression?.Accept(visitor);
        }
    }
}
