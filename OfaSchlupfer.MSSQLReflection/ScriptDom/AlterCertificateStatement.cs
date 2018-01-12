using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterCertificateStatement : CertificateStatementBase {
        private AlterCertificateStatementKind _kind;

        private Literal _attestedBy;

        public AlterCertificateStatementKind Kind {
            get {
                return this._kind;
            }
            set {
                this._kind = value;
            }
        }

        public Literal AttestedBy {
            get {
                return this._attestedBy;
            }
            set {
                base.UpdateTokenInfo(value);
                this._attestedBy = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.AttestedBy?.Accept(visitor);
        }
    }
}
