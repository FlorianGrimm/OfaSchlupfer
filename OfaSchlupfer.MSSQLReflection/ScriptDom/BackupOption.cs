namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class BackupOption : TSqlFragment {
        private ScalarExpression _value;

        public BackupOptionKind OptionKind { get; set; }

        public ScalarExpression Value {
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
