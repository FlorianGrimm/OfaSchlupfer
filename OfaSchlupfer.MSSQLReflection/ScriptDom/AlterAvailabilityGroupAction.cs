namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class AlterAvailabilityGroupAction : TSqlFragment {
        public AlterAvailabilityGroupActionType ActionType { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
