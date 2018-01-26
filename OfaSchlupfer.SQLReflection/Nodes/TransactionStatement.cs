namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class TransactionStatement : SqlStatement {
        public TransactionStatement() : base() { }
        public TransactionStatement(ScriptDom.TransactionStatement src) : base(src) {
            this.Name = Copier.Copy<IdentifierOrValueExpression>(src.Name);
        }

        public IdentifierOrValueExpression Name { get; set; }

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    public sealed class BeginTransactionStatement : TransactionStatement {
        public BeginTransactionStatement() : base() { }
        public BeginTransactionStatement(ScriptDom.BeginTransactionStatement src) : base(src) {
            this.Distributed = src.Distributed;
            this.MarkDefined = src.MarkDefined;
            this.MarkDescription = Copier.Copy<ValueExpression>(src.MarkDescription);
        }
        public bool Distributed { get; set; }

        public bool MarkDefined { get; set; }

        public ValueExpression MarkDescription { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MarkDescription?.Accept(visitor);
        }
    }
}
