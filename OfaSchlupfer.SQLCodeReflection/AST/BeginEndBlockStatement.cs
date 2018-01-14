namespace OfaSchlupfer.AST {
    [System.Serializable]
    public class BeginEndBlockStatement : TSqlStatement {
        private StatementList _statementList;

        public StatementList StatementList {
            get {
                return this._statementList;
            }

            set {
                this.UpdateTokenInfo(value);
                this._statementList = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.StatementList?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
