namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class UnqualifiedJoin : JoinTableReference {
        private UnqualifiedJoinType _unqualifiedJoinType;

        public UnqualifiedJoinType UnqualifiedJoinType {
            get {
                return this._unqualifiedJoinType;
            }

            set {
                this._unqualifiedJoinType = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
