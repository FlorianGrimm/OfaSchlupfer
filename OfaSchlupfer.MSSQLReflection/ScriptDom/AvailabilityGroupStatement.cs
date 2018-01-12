using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AvailabilityGroupStatement : TSqlStatement {
        private Identifier _name;

        private List<AvailabilityGroupOption> _options = new List<AvailabilityGroupOption>();

        private List<Identifier> _databases = new List<Identifier>();

        private List<AvailabilityReplica> _replicas = new List<AvailabilityReplica>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<AvailabilityGroupOption> Options {
            get {
                return this._options;
            }
        }

        public List<Identifier> Databases {
            get {
                return this._databases;
            }
        }

        public List<AvailabilityReplica> Replicas {
            get {
                return this._replicas;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.Databases.Count; j < count2; j++) {
                this.Databases[j].Accept(visitor);
            }
            int k = 0;
            for (int count3 = this.Replicas.Count; k < count3; k++) {
                this.Replicas[k].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
