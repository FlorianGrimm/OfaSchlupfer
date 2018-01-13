namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DeallocateCursorStatement : CursorStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
