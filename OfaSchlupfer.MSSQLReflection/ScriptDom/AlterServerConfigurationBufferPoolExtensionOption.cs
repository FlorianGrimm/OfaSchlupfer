namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class AlterServerConfigurationBufferPoolExtensionOption : TSqlFragment {

        private OptionValue _optionValue;

        public AlterServerConfigurationBufferPoolExtensionOptionKind OptionKind { get; set; }

        public OptionValue OptionValue {
            get {
                return this._optionValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._optionValue = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OptionValue?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
