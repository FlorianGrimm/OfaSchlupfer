namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class NextValueForExpression : PrimaryExpression {
        private SchemaObjectName _sequenceName;

        private OverClause _overClause;

        public SchemaObjectName SequenceName {
            get {
                return this._sequenceName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sequenceName = value;
            }
        }

        public OverClause OverClause {
            get {
                return this._overClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._overClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SequenceName?.Accept(visitor);
            this.OverClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
