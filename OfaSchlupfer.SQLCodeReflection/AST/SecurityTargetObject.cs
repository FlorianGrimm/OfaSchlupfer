namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class SecurityTargetObject : TSqlFragment {
        private SecurityObjectKind _objectKind;

        private SecurityTargetObjectName _objectName;

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

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ObjectName?.Accept(visitor);
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
