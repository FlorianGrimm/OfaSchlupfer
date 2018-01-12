using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class SequenceStatement : TSqlStatement {
        private SchemaObjectName _name;

        private List<SequenceOption> _sequenceOptions = new List<SequenceOption>();

        public SchemaObjectName Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<SequenceOption> SequenceOptions {
            get {
                return this._sequenceOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.SequenceOptions.Count; i < count; i++) {
                this.SequenceOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
