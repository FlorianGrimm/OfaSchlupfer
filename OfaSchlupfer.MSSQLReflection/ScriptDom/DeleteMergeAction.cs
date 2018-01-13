namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DeleteMergeAction : MergeAction {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
