namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BoundingBoxParameter : TSqlFragment {
        private BoundingBoxParameterType _parameter;

        private ScalarExpression _value;

        public BoundingBoxParameterType Parameter {
            get {
                return this._parameter;
            }

            set {
                this._parameter = value;
            }
        }

        public ScalarExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
