namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableTriggerModificationStatement : AlterTableStatement {
        private TriggerEnforcement _triggerEnforcement;

        public TriggerEnforcement TriggerEnforcement {
            get {
                return this._triggerEnforcement;
            }

            set {
                this._triggerEnforcement = value;
            }
        }

        public bool All { get; set; }

        public List<Identifier> TriggerNames { get; } = new List<Identifier>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.TriggerNames.Accept(visitor);
        }
    }
}
