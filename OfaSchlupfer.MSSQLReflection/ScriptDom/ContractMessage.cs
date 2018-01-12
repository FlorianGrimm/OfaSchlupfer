using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ContractMessage : TSqlFragment {
        private Identifier _name;

        private MessageSender _sentBy;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public MessageSender SentBy {
            get {
                return this._sentBy;
            }

            set {
                this._sentBy = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
