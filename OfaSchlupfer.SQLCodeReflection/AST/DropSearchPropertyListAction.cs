namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DropSearchPropertyListAction : SearchPropertyListAction {
        private StringLiteral _propertyName;

        public StringLiteral PropertyName {
            get {
                return this._propertyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._propertyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.PropertyName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
