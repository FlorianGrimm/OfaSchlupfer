namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropSchemaStatement : TSqlStatement {
        private SchemaObjectName _schema;

        private DropSchemaBehavior _dropBehavior;

        public SchemaObjectName Schema {
            get {
                return this._schema;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schema = value;
            }
        }

        public DropSchemaBehavior DropBehavior {
            get {
                return this._dropBehavior;
            }

            set {
                this._dropBehavior = value;
            }
        }

        public bool IsIfExists { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Schema != null) {
                this.Schema.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
