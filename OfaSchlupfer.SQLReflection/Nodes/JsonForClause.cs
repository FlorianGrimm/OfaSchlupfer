namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class JsonForClause : ForClause {
        public JsonForClause() : base() { }
        public JsonForClause(ScriptDom.JsonForClause src) : base(src) {
        }
        //public List<JsonForClauseOption> Options { get; } = new List<JsonForClauseOption>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            //            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
