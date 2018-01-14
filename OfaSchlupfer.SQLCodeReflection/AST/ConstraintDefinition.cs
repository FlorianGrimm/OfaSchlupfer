namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class ConstraintDefinition : TSqlFragment {
        private Identifier _constraintIdentifier;

        public Identifier ConstraintIdentifier {
            get {
                return this._constraintIdentifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._constraintIdentifier = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ConstraintIdentifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
