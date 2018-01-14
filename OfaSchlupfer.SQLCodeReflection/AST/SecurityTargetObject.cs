using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SecurityTargetObject : TSqlFragment {
        private SecurityObjectKind _objectKind;

        private SecurityTargetObjectName _objectName;

        private List<Identifier> _columns = new List<Identifier>();

        public SecurityObjectKind ObjectKind {
            get {
                return this._objectKind;
            }

            set {
                this._objectKind = value;
            }
        }

        public SecurityTargetObjectName ObjectName {
            get {
                return this._objectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._objectName = value;
            }
        }

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ObjectName?.Accept(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
