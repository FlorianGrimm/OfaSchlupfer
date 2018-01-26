#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class ProcedureParameter : DeclareVariableElement {
        public ProcedureParameter() : base() { }

        public ProcedureParameter(ScriptDom.ProcedureParameter src) : base(src) {
            this.IsVarying = src.IsVarying;
            this.Modifier = src.Modifier;
        }

        public bool IsVarying { get; set; }

        public Microsoft.SqlServer.TransactSql.ScriptDom.ParameterModifier Modifier { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
