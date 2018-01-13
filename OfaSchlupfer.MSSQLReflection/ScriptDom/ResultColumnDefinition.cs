namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ResultColumnDefinition : TSqlFragment {
        private ColumnDefinitionBase _columnDefinition;

        private NullableConstraintDefinition _nullable;

        public ColumnDefinitionBase ColumnDefinition {
            get {
                return this._columnDefinition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._columnDefinition = value;
            }
        }

        public NullableConstraintDefinition Nullable {
            get {
                return this._nullable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._nullable = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ColumnDefinition?.Accept(visitor);
            this.Nullable?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
