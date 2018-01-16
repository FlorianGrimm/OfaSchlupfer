namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DeclareCursorStatement : TSqlStatement {
        private Identifier _name;

        private CursorDefinition _cursorDefinition;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public CursorDefinition CursorDefinition {
            get {
                return this._cursorDefinition;
            }
            set {
                this.UpdateTokenInfo(value);
                this._cursorDefinition = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.CursorDefinition?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
