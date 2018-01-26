#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class ResultSetDefinition : SqlNode {
        public ResultSetDefinition() : base() { }
        public ResultSetDefinition(ScriptDom.ResultSetDefinition src) : base(src) {
            this.ResultSetType = src.ResultSetType;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.ResultSetType ResultSetType { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
