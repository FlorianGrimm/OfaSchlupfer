using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class BackupRestoreMasterKeyStatementBase : TSqlStatement {
        private Literal _file;

        private Literal _password;

        public Literal File {
            get {
                return this._file;
            }
            set {
                base.UpdateTokenInfo(value);
                this._file = value;
            }
        }

        public Literal Password {
            get {
                return this._password;
            }
            set {
                base.UpdateTokenInfo(value);
                this._password = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.File?.Accept(visitor);
            this.Password?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
