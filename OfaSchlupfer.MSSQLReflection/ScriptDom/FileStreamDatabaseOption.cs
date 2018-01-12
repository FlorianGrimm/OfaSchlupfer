using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileStreamDatabaseOption : DatabaseOption {
        private NonTransactedFileStreamAccess? _nonTransactedAccess;

        private Literal _directoryName;

        public NonTransactedFileStreamAccess? NonTransactedAccess {
            get {
                return this._nonTransactedAccess;
            }
            set {
                this._nonTransactedAccess = value;
            }
        }

        public Literal DirectoryName {
            get {
                return this._directoryName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._directoryName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DirectoryName?.Accept(visitor);
        }
    }
}
