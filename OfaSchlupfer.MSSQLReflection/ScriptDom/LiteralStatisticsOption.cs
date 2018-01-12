namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class LiteralStatisticsOption : StatisticsOption {
        private Literal _literal;

        public Literal Literal {
            get {
                return this._literal;
            }
            set {
                base.UpdateTokenInfo(value);
                this._literal = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Literal?.Accept(visitor);
        }
    }
}
