using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BackupCertificateStatement : CertificateStatementBase {
        private Literal _file;

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
