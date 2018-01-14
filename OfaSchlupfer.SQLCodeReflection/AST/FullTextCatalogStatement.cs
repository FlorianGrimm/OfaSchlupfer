using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class FullTextCatalogStatement : TSqlStatement {
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

        public List<FullTextCatalogOption> Options { get; } = new List<FullTextCatalogOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            var options = this.Options;
            for (int i = 0, count = options.Count; i < count; i++) {
                options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
