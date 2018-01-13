namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropStatisticsStatement : DropChildObjectsStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
