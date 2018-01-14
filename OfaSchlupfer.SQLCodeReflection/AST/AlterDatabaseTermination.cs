namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterDatabaseTermination : TSqlFragment {
        private Literal _rollbackAfter;

        public bool ImmediateRollback { get; set; }

        public Literal RollbackAfter {
            get {
                return this._rollbackAfter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._rollbackAfter = value;
            }
        }

        public bool NoWait { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.RollbackAfter?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
