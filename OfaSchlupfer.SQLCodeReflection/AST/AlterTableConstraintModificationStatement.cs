namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableConstraintModificationStatement : AlterTableStatement {
        private ConstraintEnforcement _existingRowsCheckEnforcement;

        private ConstraintEnforcement _constraintEnforcement;

        public ConstraintEnforcement ExistingRowsCheckEnforcement {
            get {
                return this._existingRowsCheckEnforcement;
            }

            set {
                this._existingRowsCheckEnforcement = value;
            }
        }

        public ConstraintEnforcement ConstraintEnforcement {
            get {
                return this._constraintEnforcement;
            }

            set {
                this._constraintEnforcement = value;
            }
        }

        public bool All { get; set; }

        public List<Identifier> ConstraintNames { get; } = new List<Identifier>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.ConstraintNames.Accept(visitor);
        }
    }
}
