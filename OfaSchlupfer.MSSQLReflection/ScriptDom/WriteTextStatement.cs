namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class WriteTextStatement : TextModificationStatement {
        private ValueExpression _sourceParameter;

        public ValueExpression SourceParameter {
            get {
                return this._sourceParameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sourceParameter = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SourceParameter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
