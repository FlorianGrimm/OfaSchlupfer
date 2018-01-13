namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateEventSessionStatement : EventSessionStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
