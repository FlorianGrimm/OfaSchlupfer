namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WitnessDatabaseOption : DatabaseOption {
        private Literal _witnessServer;

        public Literal WitnessServer {
            get {
                return this._witnessServer;
            }
            set {
                base.UpdateTokenInfo(value);
                this._witnessServer = value;
            }
        }

        public bool IsOff { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.WitnessServer?.Accept(visitor);
        }
    }
}
