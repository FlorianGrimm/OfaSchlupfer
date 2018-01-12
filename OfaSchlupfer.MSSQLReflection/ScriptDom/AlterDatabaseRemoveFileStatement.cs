using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseRemoveFileStatement : AlterDatabaseStatement {
        private Identifier _file;

        public Identifier File {
            get {
                return this._file;
            }

            set {
                this.UpdateTokenInfo(value);
                this._file = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.File?.Accept(visitor);
        }
    }
}
