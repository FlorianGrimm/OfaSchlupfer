namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateSequenceStatement : SequenceStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
