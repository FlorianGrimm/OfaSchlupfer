namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class XmlForClauseOption : ForClause {
        private Literal _value;

        public XmlForClauseOptions OptionKind { get; set; }

        public Literal Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
