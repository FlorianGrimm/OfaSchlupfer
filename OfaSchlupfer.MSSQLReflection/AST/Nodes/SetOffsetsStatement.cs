#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class SetOffsetsStatement : SetOnOffStatement {
        public SetOffsetsStatement() : base() { }
        public SetOffsetsStatement(ScriptDom.SetOffsetsStatement src) : base(src) {
            this.Options = src.Options;
        }
        public Microsoft.SqlServer.TransactSql.ScriptDom.SetOffsets Options;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
