namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InlineResultSetDefinition : ResultSetDefinition {
        public InlineResultSetDefinition() : base() { }
        public InlineResultSetDefinition(ScriptDom.InlineResultSetDefinition src) : base(src) {
            Copier.CopyList(this.ResultColumnDefinitions, src.ResultColumnDefinitions);
        }
        public List<ResultColumnDefinition> ResultColumnDefinitions { get; } = new List<ResultColumnDefinition>();

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ResultColumnDefinitions.Accept(visitor);
        }
    }
}
