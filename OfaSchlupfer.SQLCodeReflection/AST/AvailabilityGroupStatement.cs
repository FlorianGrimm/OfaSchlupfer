namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class AvailabilityGroupStatement : TSqlStatement {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<AvailabilityGroupOption> Options { get; } = new List<AvailabilityGroupOption>();

        public List<Identifier> Databases { get; } = new List<Identifier>();

        public List<AvailabilityReplica> Replicas { get; } = new List<AvailabilityReplica>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.Options.Accept(visitor);
            this.Databases.Accept(visitor);
            this.Replicas.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
