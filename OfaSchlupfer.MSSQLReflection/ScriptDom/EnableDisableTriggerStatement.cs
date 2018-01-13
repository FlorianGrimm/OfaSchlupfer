using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class EnableDisableTriggerStatement : TSqlStatement {
        private TriggerEnforcement _triggerEnforcement;

        private bool _all;

        private List<SchemaObjectName> _triggerNames = new List<SchemaObjectName>();

        private TriggerObject _triggerObject;

        public TriggerEnforcement TriggerEnforcement {
            get {
                return this._triggerEnforcement;
            }

            set {
                this._triggerEnforcement = value;
            }
        }

        public bool All {
            get {
                return this._all;
            }

            set {
                this._all = value;
            }
        }

        public List<SchemaObjectName> TriggerNames {
            get {
                return this._triggerNames;
            }
        }

        public TriggerObject TriggerObject {
            get {
                return this._triggerObject;
            }

            set {
                this.UpdateTokenInfo(value);
                this._triggerObject = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.TriggerNames.Count; i < count; i++) {
                this.TriggerNames[i].Accept(visitor);
            }
            this.TriggerObject?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
