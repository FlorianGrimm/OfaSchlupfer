using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class RemoteServiceBindingStatementBase : TSqlStatement {
        private Identifier _name;

        private List<RemoteServiceBindingOption> _options = new List<RemoteServiceBindingOption>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<RemoteServiceBindingOption> Options {
            get {
                return this._options;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
