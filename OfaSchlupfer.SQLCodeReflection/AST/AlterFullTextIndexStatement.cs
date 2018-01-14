namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterFullTextIndexStatement : TSqlStatement {
        private SchemaObjectName _onName;

        private AlterFullTextIndexAction _action;

        public SchemaObjectName OnName {
            get {
                return this._onName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onName = value;
            }
        }

        public AlterFullTextIndexAction Action {
            get {
                return this._action;
            }

            set {
                this.UpdateTokenInfo(value);
                this._action = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OnName?.Accept(visitor);
            this.Action?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
