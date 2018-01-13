namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ColumnStorageOptions : TSqlFragment {
        private bool _isFileStream;

        private SparseColumnOption _sparseOption;

        public bool IsFileStream {
            get {
                return this._isFileStream;
            }

            set {
                this._isFileStream = value;
            }
        }

        public SparseColumnOption SparseOption {
            get {
                return this._sparseOption;
            }

            set {
                this._sparseOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
