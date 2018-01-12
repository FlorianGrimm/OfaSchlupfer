using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseModifyFileStatement : AlterDatabaseStatement {
        private FileDeclaration _fileDeclaration;

        public FileDeclaration FileDeclaration {
            get {
                return this._fileDeclaration;
            }
            set {
                base.UpdateTokenInfo(value);
                this._fileDeclaration = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileDeclaration?.Accept(visitor);
        }
    }
}
