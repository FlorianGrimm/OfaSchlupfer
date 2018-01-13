namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterAvailabilityGroupStatement : AvailabilityGroupStatement {
        private AlterAvailabilityGroupStatementType _alterAvailabilityGroupStatementType;

        private AlterAvailabilityGroupAction _action;

        public AlterAvailabilityGroupStatementType AlterAvailabilityGroupStatementType {
            get {
                return this._alterAvailabilityGroupStatementType;
            }

            set {
                this._alterAvailabilityGroupStatementType = value;
            }
        }

        public AlterAvailabilityGroupAction Action {
            get {
                return this._action;
            }

            set {
                this.UpdateTokenInfo(value);
                this._action = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Action?.Accept(visitor);
        }
    }
}
