using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseCollateStatement : AlterDatabaseStatement, ICollationSetter {
        private Identifier _collation;

        public Identifier Collation {
            get {
                return this._collation;
            }

            set {
                this.UpdateTokenInfo(value);
                this._collation = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Collation?.Accept(visitor);
        }
    }
}
