namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ExecuteStatement : TSqlStatement {
        private ExecuteSpecification _executeSpecification;

        private List<ExecuteOption> _options = new List<ExecuteOption>();

        public ExecuteSpecification ExecuteSpecification {
            get {
                return this._executeSpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._executeSpecification = value;
            }
        }

        public List<ExecuteOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.ExecuteSpecification != null) {
                this.ExecuteSpecification.Accept(visitor);
            }
            int i = 0;
            for (int count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
