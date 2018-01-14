using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterTableTriggerModificationStatement : AlterTableStatement {
        private TriggerEnforcement _triggerEnforcement;

        private List<Identifier> _triggerNames = new List<Identifier>();

        public TriggerEnforcement TriggerEnforcement {
            get {
                return this._triggerEnforcement;
            }

            set {
                this._triggerEnforcement = value;
            }
        }

        public bool All { get; set; }

        public List<Identifier> TriggerNames {
            get {
                return this._triggerNames;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            for (int i = 0, count = this.TriggerNames.Count; i < count; i++) {
                this.TriggerNames[i].Accept(visitor);
            }
        }
    }
}
