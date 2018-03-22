#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public abstract class TransactionStatement : SqlStatement {
        public TransactionStatement() : base() { }
        public TransactionStatement(ScriptDom.TransactionStatement src) : base(src) {
            this.Name = Copier.Copy<IdentifierOrValueExpression>(src.Name);
        }
        public IdentifierOrValueExpression Name;
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class BeginTransactionStatement : TransactionStatement {
        public BeginTransactionStatement() : base() { }
        public BeginTransactionStatement(ScriptDom.BeginTransactionStatement src) : base(src) {
            this.Distributed = src.Distributed;
            this.MarkDefined = src.MarkDefined;
            this.MarkDescription = Copier.Copy<ValueExpression>(src.MarkDescription);
        }
        public bool Distributed;
        public bool MarkDefined;
        public ValueExpression MarkDescription;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MarkDescription?.Accept(visitor);
        }
    }
}
