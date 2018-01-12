using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class IndexType : TSqlFragment {
        private IndexTypeKind? _indexTypeKind;

        public IndexTypeKind? IndexTypeKind {
            get {
                return this._indexTypeKind;
            }

            set {
                this._indexTypeKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
