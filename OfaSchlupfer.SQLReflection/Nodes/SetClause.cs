namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class SetClause : SqlNode {
        public SetClause() : base() { }
        public SetClause(ScriptDom.SetClause src) : base(src) {
        }
    }
}
namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class FunctionCallSetClause : SetClause {
        public FunctionCallSetClause() : base() { }
        public FunctionCallSetClause(ScriptDom.FunctionCallSetClause src) : base(src) {
            this.MutatorFunction = Copier.Copy<FunctionCall>(src.MutatorFunction);
        }

        public FunctionCall MutatorFunction { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.MutatorFunction?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
