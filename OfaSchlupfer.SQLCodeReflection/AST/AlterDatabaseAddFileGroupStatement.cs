namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterDatabaseAddFileGroupStatement : AlterDatabaseStatement {
        private Identifier _fileGroup;

        public Identifier FileGroup {
            get {
                return this._fileGroup;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileGroup = value;
            }
        }

        public bool ContainsFileStream { get; set; }

        public bool ContainsMemoryOptimizedData { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileGroup?.Accept(visitor);
        }
    }
}
