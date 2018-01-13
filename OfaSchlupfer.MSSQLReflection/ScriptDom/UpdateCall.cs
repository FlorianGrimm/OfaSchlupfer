namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UpdateCall : BooleanExpression {
        private Identifier _identifier;

        public Identifier Identifier {
            get {
                return this._identifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._identifier = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifier?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
