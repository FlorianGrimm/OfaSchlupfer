namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateTriggerStatement : TriggerStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
