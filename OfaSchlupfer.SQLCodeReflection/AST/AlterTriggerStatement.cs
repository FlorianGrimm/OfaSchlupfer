namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterTriggerStatement : TriggerStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
