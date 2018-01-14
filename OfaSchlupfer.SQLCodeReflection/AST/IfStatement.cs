namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class IfStatement : TSqlStatement {
        private BooleanExpression _predicate;

        private TSqlStatement _thenStatement;

        private TSqlStatement _elseStatement;

        public BooleanExpression Predicate {
            get {
                return this._predicate;
            }

            set {
                this.UpdateTokenInfo(value);
                this._predicate = value;
            }
        }

        public TSqlStatement ThenStatement {
            get {
                return this._thenStatement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._thenStatement = value;
            }
        }

        public TSqlStatement ElseStatement {
            get {
                return this._elseStatement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._elseStatement = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Predicate?.Accept(visitor);
            this.ThenStatement?.Accept(visitor);
            this.ElseStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
