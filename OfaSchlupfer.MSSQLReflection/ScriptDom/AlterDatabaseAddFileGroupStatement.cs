namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseAddFileGroupStatement : AlterDatabaseStatement {
        private Identifier _fileGroup;

        private bool _containsFileStream;

        private bool _containsMemoryOptimizedData;

        public Identifier FileGroup {
            get {
                return this._fileGroup;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileGroup = value;
            }
        }

        public bool ContainsFileStream {
            get {
                return this._containsFileStream;
            }

            set {
                this._containsFileStream = value;
            }
        }

        public bool ContainsMemoryOptimizedData {
            get {
                return this._containsMemoryOptimizedData;
            }

            set {
                this._containsMemoryOptimizedData = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileGroup?.Accept(visitor);
        }
    }
}
