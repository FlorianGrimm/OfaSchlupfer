namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ResourcePoolStatement : TSqlStatement {
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

        public List<ResourcePoolParameter> ResourcePoolParameters { get; } = new List<ResourcePoolParameter>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            var resourcePoolParameters = this.ResourcePoolParameters;
            for (int i = 0, count = resourcePoolParameters.Count; i < count; i++) {
                resourcePoolParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
