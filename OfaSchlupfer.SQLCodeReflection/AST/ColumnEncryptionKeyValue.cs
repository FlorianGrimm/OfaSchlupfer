namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ColumnEncryptionKeyValue : TSqlFragment {
        public List<ColumnEncryptionKeyValueParameter> Parameters { get; } = new List<ColumnEncryptionKeyValueParameter>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Parameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
