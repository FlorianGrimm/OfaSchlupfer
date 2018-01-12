using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseRemoveFileGroupStatement : AlterDatabaseStatement {
        private Identifier _fileGroup;

        public Identifier FileGroup {
            get {
                return this._fileGroup;
            }
            set {
                base.UpdateTokenInfo(value);
                this._fileGroup = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileGroup?.Accept(visitor);
        }
    }
}
