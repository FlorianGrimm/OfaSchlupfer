using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServerConfigurationSetFailoverClusterPropertyStatement : TSqlStatement {
        private List<AlterServerConfigurationFailoverClusterPropertyOption> _options = new List<AlterServerConfigurationFailoverClusterPropertyOption>();

        public List<AlterServerConfigurationFailoverClusterPropertyOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
