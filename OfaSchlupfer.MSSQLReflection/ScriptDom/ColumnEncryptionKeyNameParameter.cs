namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnEncryptionKeyNameParameter : ColumnEncryptionDefinitionParameter {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this._name = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
