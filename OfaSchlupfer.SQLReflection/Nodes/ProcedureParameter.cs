namespace OfaSchlupfer.SQLReflection {
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
