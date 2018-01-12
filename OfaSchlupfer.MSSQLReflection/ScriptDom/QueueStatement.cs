using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class QueueStatement : TSqlStatement {
        private SchemaObjectName _name;

        private List<QueueOption> _queueOptions = new List<QueueOption>();

        public SchemaObjectName Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<QueueOption> QueueOptions {
            get {
                return this._queueOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.QueueOptions.Count; i < count; i++) {
                this.QueueOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
