using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterTableConstraintModificationStatement : AlterTableStatement {
        private ConstraintEnforcement _existingRowsCheckEnforcement;

        private ConstraintEnforcement _constraintEnforcement;

        private bool _all;

        private List<Identifier> _constraintNames = new List<Identifier>();

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

        public bool All {
            get {
                return this._all;
            }

            set {
                this._all = value;
            }
        }

        public List<Identifier> ConstraintNames {
            get {
                return this._constraintNames;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            for (int i=0, count = this.ConstraintNames.Count; i < count; i++) {
                this.ConstraintNames[i].Accept(visitor);
            }
        }
    }
}
