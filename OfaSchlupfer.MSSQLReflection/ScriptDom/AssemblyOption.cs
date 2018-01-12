namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class AssemblyOption : TSqlFragment {
        private AssemblyOptionKind _optionKind;

        public AssemblyOptionKind OptionKind {
            get {
                return this._optionKind;
            }
            set {
                this._optionKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
