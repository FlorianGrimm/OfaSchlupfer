namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ServiceContract : TSqlFragment {
        private Identifier _name;

        private AlterAction _action;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public AlterAction Action {
            get {
                return this._action;
            }

            set {
                this._action = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
