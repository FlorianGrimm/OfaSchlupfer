namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class WorkloadGroupStatement : TSqlStatement {
        private Identifier _name;

        private Identifier _poolName;

        private Identifier _externalPoolName;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<WorkloadGroupParameter> WorkloadGroupParameters { get; } = new List<WorkloadGroupParameter>();

        public Identifier PoolName {
            get {
                return this._poolName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._poolName = value;
            }
        }

        public Identifier ExternalPoolName {
            get {
                return this._externalPoolName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._externalPoolName = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.WorkloadGroupParameters.Accept(visitor);
            this.PoolName?.Accept(visitor);
            this.ExternalPoolName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
