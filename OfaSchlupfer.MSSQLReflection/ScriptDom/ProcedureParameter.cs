namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ProcedureParameter : DeclareVariableElement {
        public bool IsVarying { get; set; }

        public ParameterModifier Modifier { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
