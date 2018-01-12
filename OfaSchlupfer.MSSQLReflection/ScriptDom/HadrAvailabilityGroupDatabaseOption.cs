namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class HadrAvailabilityGroupDatabaseOption : HadrDatabaseOption {
        private Identifier _groupName;

        public Identifier GroupName {
            get {
                return this._groupName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._groupName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.GroupName?.Accept(visitor);
        }
    }
}
