namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class VariableTableReference : TableReferenceWithAlias {
        private VariableReference _variable;

        public VariableReference Variable {
            get {
                return this._variable;
            }

            set {
                this.UpdateTokenInfo(value);
                this._variable = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Variable?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
