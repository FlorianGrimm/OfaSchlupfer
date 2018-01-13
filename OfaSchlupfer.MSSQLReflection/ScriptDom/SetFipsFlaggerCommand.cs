namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetFipsFlaggerCommand : SetCommand {
        private FipsComplianceLevel _complianceLevel;

        public FipsComplianceLevel ComplianceLevel {
            get {
                return this._complianceLevel;
            }

            set {
                this._complianceLevel = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
