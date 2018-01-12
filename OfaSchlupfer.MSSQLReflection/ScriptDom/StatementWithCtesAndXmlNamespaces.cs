using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class StatementWithCtesAndXmlNamespaces : TSqlStatement {
        private WithCtesAndXmlNamespaces _withCtesAndXmlNamespaces;

        private List<OptimizerHint> _optimizerHints = new List<OptimizerHint>();

        public WithCtesAndXmlNamespaces WithCtesAndXmlNamespaces {
            get {
                return this._withCtesAndXmlNamespaces;
            }
            set {
                base.UpdateTokenInfo(value);
                this._withCtesAndXmlNamespaces = value;
            }
        }

        public List<OptimizerHint> OptimizerHints {
            get {
                return this._optimizerHints;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.WithCtesAndXmlNamespaces?.Accept(visitor);
            for (int i=0, count = this.OptimizerHints.Count; i < count; i++) {
                this.OptimizerHints[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
