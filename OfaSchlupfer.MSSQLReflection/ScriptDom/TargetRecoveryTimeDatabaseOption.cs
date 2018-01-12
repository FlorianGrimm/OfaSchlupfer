namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TargetRecoveryTimeDatabaseOption : DatabaseOption {
        private Literal _recoveryTime;

        public Literal RecoveryTime {
            get {
                return this._recoveryTime;
            }
            set {
                base.UpdateTokenInfo(value);
                this._recoveryTime = value;
            }
        }

        public TimeUnit Unit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.RecoveryTime?.Accept(visitor);
        }
    }
}
