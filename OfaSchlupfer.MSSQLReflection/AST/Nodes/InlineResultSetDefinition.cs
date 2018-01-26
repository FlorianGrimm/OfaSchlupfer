#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

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
