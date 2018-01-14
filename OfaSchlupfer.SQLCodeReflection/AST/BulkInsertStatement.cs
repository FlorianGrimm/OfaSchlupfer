namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class BulkInsertStatement : BulkInsertBase {
        private IdentifierOrValueExpression _from;

        public IdentifierOrValueExpression From {
            get {
                return this._from;
            }

            set {
                this.UpdateTokenInfo(value);
                this._from = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.To != null) {
                base.To.Accept(visitor);
            }
            this.From?.Accept(visitor);
            for (int i = 0, count = base.Options.Count; i < count; i++) {
                base.Options[i].Accept(visitor);
            }
        }
    }
}
