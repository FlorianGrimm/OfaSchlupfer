namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterDatabaseAddFileStatement : AlterDatabaseStatement {
        private List<FileDeclaration> _fileDeclarations = new List<FileDeclaration>();

        private Identifier _fileGroup;

        public List<FileDeclaration> FileDeclarations {
            get {
                return this._fileDeclarations;
            }
        }

        public Identifier FileGroup {
            get {
                return this._fileGroup;
            }

            set {
                this.UpdateTokenInfo(value);
                this._fileGroup = value;
            }
        }

        public bool IsLog { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.FileDeclarations.Count; i < count; i++) {
                this.FileDeclarations[i].Accept(visitor);
            }
            this.FileGroup?.Accept(visitor);
        }
    }
}
