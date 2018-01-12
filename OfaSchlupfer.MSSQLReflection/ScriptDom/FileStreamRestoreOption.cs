using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileStreamRestoreOption : RestoreOption {
        private FileStreamDatabaseOption _fileStreamOption;

        public FileStreamDatabaseOption FileStreamOption {
            get {
                return this._fileStreamOption;
            }
            set {
                base.UpdateTokenInfo(value);
                this._fileStreamOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FileStreamOption?.Accept(visitor);
        }
    }
}
