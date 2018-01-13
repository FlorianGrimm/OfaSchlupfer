namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterSearchPropertyListStatement : TSqlStatement {
        private Identifier _name;

        private SearchPropertyListAction _action;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SearchPropertyListAction Action {
            get {
                return this._action;
            }

            set {
                this.UpdateTokenInfo(value);
                this._action = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Action?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
