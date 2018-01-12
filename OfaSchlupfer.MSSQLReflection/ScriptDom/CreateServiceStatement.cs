using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateServiceStatement : AlterCreateServiceStatementBase, IAuthorization {
        private Identifier _owner;

        public Identifier Owner {
            get {
                return this._owner;
            }
            set {
                base.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            if (base.QueueName != null) {
                base.QueueName.Accept(visitor);
            }
            for (int i=0, count = base.ServiceContracts.Count; i < count; i++) {
                base.ServiceContracts[i].Accept(visitor);
            }
            this.Owner?.Accept(visitor);
        }
    }
}
