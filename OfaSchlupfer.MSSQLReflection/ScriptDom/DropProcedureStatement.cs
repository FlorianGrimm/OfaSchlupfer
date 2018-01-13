namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropProcedureStatement : DropObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
