namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class EnableDisableTriggerStatement : TSqlStatement {
        private TriggerEnforcement _triggerEnforcement;

        private TriggerObject _triggerObject;

        public TriggerEnforcement TriggerEnforcement {
            get {
                return this._triggerEnforcement;
            }

            set {
                this._triggerEnforcement = value;
            }
        }

        public bool All { get; set; }

        public List<SchemaObjectName> TriggerNames { get; } = new List<SchemaObjectName>();

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
            this.TriggerNames.Accept(visitor);
            this.TriggerObject?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
