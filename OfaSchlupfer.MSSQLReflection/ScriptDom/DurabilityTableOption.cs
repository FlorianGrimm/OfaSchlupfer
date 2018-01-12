namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DurabilityTableOption : TableOption {
        private DurabilityTableOptionKind _durabilityTableOptionKind;

        public DurabilityTableOptionKind DurabilityTableOptionKind {
            get {
                return this._durabilityTableOptionKind;
            }
            set {
                this._durabilityTableOptionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
