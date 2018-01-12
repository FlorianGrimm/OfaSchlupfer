namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExecuteAsProcedureOption : ProcedureOption {
        private ExecuteAsClause _executeAs;

        public ExecuteAsClause ExecuteAs {
            get {
                return this._executeAs;
            }
            set {
                base.UpdateTokenInfo(value);
                this._executeAs = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ExecuteAs?.Accept(visitor);
        }
    }
}
