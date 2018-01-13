namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PredicateSetStatement : SetOnOffStatement {
        private SetOptions _options;

        public SetOptions Options {
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
