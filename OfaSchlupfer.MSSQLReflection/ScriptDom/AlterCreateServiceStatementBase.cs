using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AlterCreateServiceStatementBase : TSqlStatement {
        private Identifier _name;

        private SchemaObjectName _queueName;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SchemaObjectName QueueName {
            get {
                return this._queueName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._queueName = value;
            }
        }

        public List<ServiceContract> ServiceContracts { get; } = new List<ServiceContract>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.QueueName?.Accept(visitor);
            for (int i = 0, count = this.ServiceContracts.Count; i < count; i++) {
                this.ServiceContracts[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
