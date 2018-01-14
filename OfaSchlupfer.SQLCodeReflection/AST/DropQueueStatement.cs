namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropQueueStatement : TSqlStatement {
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

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
