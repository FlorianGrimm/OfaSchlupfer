namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ExecuteStatement : TSqlStatement {
        private ExecuteSpecification _executeSpecification;

        public ExecuteSpecification ExecuteSpecification {
            get {
                return this._executeSpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._executeSpecification = value;
            }
        }

        public List<ExecuteOption> Options { get; } = new List<ExecuteOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.ExecuteSpecification?.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
