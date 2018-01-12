using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseSetStatement : AlterDatabaseStatement {
        private AlterDatabaseTermination _termination;

        private List<DatabaseOption> _options = new List<DatabaseOption>();

        public AlterDatabaseTermination Termination {
            get {
                return this._termination;
            }
            set {
                base.UpdateTokenInfo(value);
                this._termination = value;
            }
        }

        public List<DatabaseOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Termination?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }
}
