namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateSchemaStatement : TSqlStatement, IAuthorization {
        private Identifier _name;

        private StatementList _statementList;

        private Identifier _owner;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public StatementList StatementList {
            get {
                return this._statementList;
            }

            set {
                this.UpdateTokenInfo(value);
                this._statementList = value;
            }
        }

        public Identifier Owner {
            get {
                return this._owner;
            }

            set {
                this.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.StatementList?.Accept(visitor);
            this.Owner?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
