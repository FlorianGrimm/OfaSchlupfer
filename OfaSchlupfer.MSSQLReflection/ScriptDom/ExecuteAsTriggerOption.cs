namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExecuteAsTriggerOption : TriggerOption {
        private ExecuteAsClause _executeAsClause;

        public ExecuteAsClause ExecuteAsClause {
            get {
                return this._executeAsClause;
            }
            set {
                base.UpdateTokenInfo(value);
                this._executeAsClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);


        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ExecuteAsClause?.Accept(visitor);
        }
    }
}
