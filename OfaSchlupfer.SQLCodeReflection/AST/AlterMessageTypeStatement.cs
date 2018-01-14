namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterMessageTypeStatement : MessageTypeStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
