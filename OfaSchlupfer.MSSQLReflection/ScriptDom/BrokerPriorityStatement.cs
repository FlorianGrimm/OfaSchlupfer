using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class BrokerPriorityStatement : TSqlStatement {
        private Identifier _name;

        private List<BrokerPriorityParameter> _brokerPriorityParameters = new List<BrokerPriorityParameter>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<BrokerPriorityParameter> BrokerPriorityParameters {
            get {
                return this._brokerPriorityParameters;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i = 0, count = this.BrokerPriorityParameters.Count; i < count; i++) {
                this.BrokerPriorityParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
