namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class SchemaDeclarationItem : TSqlFragment {
        private ColumnDefinitionBase _columnDefinition;

        private ValueExpression _mapping;

        public ColumnDefinitionBase ColumnDefinition {
            get {
                return this._columnDefinition;
            }
            set {
                base.UpdateTokenInfo(value);
                this._columnDefinition = value;
            }
        }

        public ValueExpression Mapping {
            get {
                return this._mapping;
            }
            set {
                base.UpdateTokenInfo(value);
                this._mapping = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ColumnDefinition?.Accept(visitor);
            this.Mapping?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
