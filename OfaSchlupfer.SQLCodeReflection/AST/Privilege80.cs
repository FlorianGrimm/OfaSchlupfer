namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class Privilege80 : TSqlFragment {
        private PrivilegeType80 _privilegeType80;

        public List<Identifier> Columns { get; } = new List<Identifier>();

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
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
