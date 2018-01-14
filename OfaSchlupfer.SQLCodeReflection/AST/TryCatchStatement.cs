namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class TryCatchStatement : TSqlStatement {
        private StatementList _tryStatements;

        private StatementList _catchStatements;

        public StatementList TryStatements {
            get {
                return this._tryStatements;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tryStatements = value;
            }
        }

        public StatementList CatchStatements {
            get {
                return this._catchStatements;
            }

            set {
                this.UpdateTokenInfo(value);
                this._catchStatements = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TryStatements?.Accept(visitor);
            this.CatchStatements?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
