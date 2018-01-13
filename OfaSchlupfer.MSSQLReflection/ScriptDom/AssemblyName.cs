namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AssemblyName : TSqlFragment {
        private Identifier _name;

        private Identifier _className;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public Identifier ClassName {
            get {
                return this._className;
            }

            set {
                this.UpdateTokenInfo(value);
                this._className = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ClassName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
