namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterDatabaseSetStatement : AlterDatabaseStatement {
        private AlterDatabaseTermination _termination;

        public AlterDatabaseTermination Termination {
            get {
                return this._termination;
            }

            set {
                this.UpdateTokenInfo(value);
                this._termination = value;
            }
        }

        public List<DatabaseOption> Options { get; } = new List<DatabaseOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Termination?.Accept(visitor);
            this.Options.Accept(visitor);
        }
    }
}
