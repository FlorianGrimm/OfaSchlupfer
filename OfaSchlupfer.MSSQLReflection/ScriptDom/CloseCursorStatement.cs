namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CloseCursorStatement : CursorStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
