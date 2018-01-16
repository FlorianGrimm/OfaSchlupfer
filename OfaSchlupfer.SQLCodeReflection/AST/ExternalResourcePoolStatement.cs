namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ExternalResourcePoolStatement : TSqlStatement {
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

        public List<ExternalResourcePoolParameter> ExternalResourcePoolParameters { get; } = new List<ExternalResourcePoolParameter>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ExternalResourcePoolParameters.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
