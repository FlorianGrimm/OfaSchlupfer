namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ExternalTableColumnDefinition : TSqlFragment {
        private ColumnDefinitionBase _columnDefinition;

        private NullableConstraintDefinition _nullableConstraint;

        public ColumnDefinitionBase ColumnDefinition {
            get {
                return this._columnDefinition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._columnDefinition = value;
            }
        }

        public NullableConstraintDefinition NullableConstraint {
            get {
                return this._nullableConstraint;
            }

            set {
                this.UpdateTokenInfo(value);
                this._nullableConstraint = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ColumnDefinition?.Accept(visitor);
            this.NullableConstraint?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
