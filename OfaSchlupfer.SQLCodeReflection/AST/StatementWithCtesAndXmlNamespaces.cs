namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class StatementWithCtesAndXmlNamespaces : TSqlStatement {
        private WithCtesAndXmlNamespaces _withCtesAndXmlNamespaces;

        public WithCtesAndXmlNamespaces WithCtesAndXmlNamespaces {
            get {
                return this._withCtesAndXmlNamespaces;
            }

            set {
                this.UpdateTokenInfo(value);
                this._withCtesAndXmlNamespaces = value;
            }
        }

        public List<OptimizerHint> OptimizerHints { get; } = new List<OptimizerHint>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.WithCtesAndXmlNamespaces?.Accept(visitor);
            this.OptimizerHints.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
