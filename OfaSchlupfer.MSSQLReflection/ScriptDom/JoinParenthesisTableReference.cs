namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class JoinParenthesisTableReference : TableReference {
        private TableReference _join;

        public TableReference Join {
            get {
                return this._join;
            }

            set {
                this.UpdateTokenInfo(value);
                this._join = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Join?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
