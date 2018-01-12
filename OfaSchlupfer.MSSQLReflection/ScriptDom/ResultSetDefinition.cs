namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class ResultSetDefinition : TSqlFragment {
        private ResultSetType _resultSetType;

        public ResultSetType ResultSetType {
            get {
                return this._resultSetType;
            }

            set {
                this._resultSetType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
