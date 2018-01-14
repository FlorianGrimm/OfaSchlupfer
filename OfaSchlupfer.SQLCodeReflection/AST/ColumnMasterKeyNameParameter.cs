namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ColumnMasterKeyNameParameter : ColumnEncryptionKeyValueParameter {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Name?.Accept(visitor);
        }
    }
}
