namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateOrAlterTriggerStatement : TriggerStatementBody {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
