namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BreakStatement : TSqlStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
