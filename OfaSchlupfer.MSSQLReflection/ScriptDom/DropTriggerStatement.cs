namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropTriggerStatement : DropObjectsStatement {
        public TriggerScope TriggerScope { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
