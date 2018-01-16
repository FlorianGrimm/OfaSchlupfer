namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterDatabaseAddFileStatement : AlterDatabaseStatement {
        private Identifier _fileGroup;

        public List<FileDeclaration> FileDeclarations { get; } = new List<FileDeclaration>();

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
            this.FileDeclarations.Accept(visitor);
            this.FileGroup?.Accept(visitor);
        }
    }
}
