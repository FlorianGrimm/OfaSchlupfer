namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class DataTypeReference : TSqlFragment {
        private SchemaObjectName _name;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
