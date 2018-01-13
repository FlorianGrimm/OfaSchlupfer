namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SetStatisticsStatement : SetOnOffStatement {
        private SetStatisticsOptions _options;

        public SetStatisticsOptions Options {
            get {
                return this._options;
            }

            set {
                this._options = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
