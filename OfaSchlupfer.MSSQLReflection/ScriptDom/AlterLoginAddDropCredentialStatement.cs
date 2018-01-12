using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterLoginAddDropCredentialStatement : AlterLoginStatement {
        private bool _isAdd;

        private Identifier _credentialName;

        public bool IsAdd {
            get {
                return this._isAdd;
            }
            set {
                this._isAdd = value;
            }
        }

        public Identifier CredentialName {
            get {
                return this._credentialName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._credentialName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.CredentialName?.Accept(visitor);
        }
    }
}
