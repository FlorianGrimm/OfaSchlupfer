using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileEncryptionSource : EncryptionSource {
        private bool _isExecutable;

        private Literal _file;

        public bool IsExecutable {
            get {
                return this._isExecutable;
            }
            set {
                this._isExecutable = value;
            }
        }

        public Literal File {
            get {
                return this._file;
            }
            set {
                base.UpdateTokenInfo(value);
                this._file = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.File?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
