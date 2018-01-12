using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class Privilege80 : TSqlFragment {
        private List<Identifier> _columns = new List<Identifier>();

        private PrivilegeType80 _privilegeType80;

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public PrivilegeType80 PrivilegeType80 {
            get {
                return this._privilegeType80;
            }

            set {
                this._privilegeType80 = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
