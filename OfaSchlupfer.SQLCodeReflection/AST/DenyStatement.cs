namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DenyStatement : SecurityStatement {
        public bool CascadeOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            int i = 0;
            for (int count = base.Permissions.Count; i < count; i++) {
                base.Permissions[i].Accept(visitor);
            }
            if (base.SecurityTargetObject != null) {
                base.SecurityTargetObject.Accept(visitor);
            }
            int j = 0;
            for (int count2 = base.Principals.Count; j < count2; j++) {
                base.Principals[j].Accept(visitor);
            }
            if (base.AsClause != null) {
                base.AsClause.Accept(visitor);
            }
        }
    }
}
