using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServiceMasterKeyStatement : TSqlStatement {
        private Literal _account;

        private Literal _password;

        private AlterServiceMasterKeyOption _kind;

        public Literal Account {
            get {
                return this._account;
            }
            set {
                base.UpdateTokenInfo(value);
                this._account = value;
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

        public AlterServiceMasterKeyOption Kind {
            get {
                return this._kind;
            }
            set {
                this._kind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Account?.Accept(visitor);
            this.Password?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
