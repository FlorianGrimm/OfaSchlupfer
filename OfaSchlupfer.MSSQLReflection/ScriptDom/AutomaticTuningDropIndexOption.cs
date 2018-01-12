namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AutomaticTuningDropIndexOption : AutomaticTuningOption {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
