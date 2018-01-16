namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class BrokerPriorityStatement : TSqlStatement {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<BrokerPriorityParameter> BrokerPriorityParameters { get; } = new List<BrokerPriorityParameter>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.BrokerPriorityParameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
