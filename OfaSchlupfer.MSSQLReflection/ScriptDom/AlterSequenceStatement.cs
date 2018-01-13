namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterSequenceStatement : SequenceStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
