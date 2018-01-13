namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SelectInsertSource : InsertSource {
        private QueryExpression _select;

        public QueryExpression Select {
            get {
                return this._select;
            }

            set {
                this.UpdateTokenInfo(value);
                this._select = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Select?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
