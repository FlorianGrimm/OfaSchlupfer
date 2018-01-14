#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class ColumnStorageOptions : TSqlFragment {
        public bool IsFileStream { get; set; }

        public SparseColumnOption SparseOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
