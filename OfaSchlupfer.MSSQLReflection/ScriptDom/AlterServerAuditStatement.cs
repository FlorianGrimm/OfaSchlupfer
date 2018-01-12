using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServerAuditStatement : ServerAuditStatement {
        private Identifier _newName;

        private bool _removeWhere;

        public Identifier NewName {
            get {
                return this._newName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._newName = value;
            }
        }

        public bool RemoveWhere {
            get {
                return this._removeWhere;
            }
            set {
                this._removeWhere = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.NewName?.Accept(visitor);
        }
    }
}
