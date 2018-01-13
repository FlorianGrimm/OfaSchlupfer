using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AssemblyStatement : TSqlStatement {
        private Identifier _name;

        private List<ScalarExpression> _parameters = new List<ScalarExpression>();

        private List<AssemblyOption> _options = new List<AssemblyOption>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ScalarExpression> Parameters {
            get {
                return this._parameters;
            }
        }

        public List<AssemblyOption> Options {
            get {
                return this._options;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i = 0, count = this.Parameters.Count; i < count; i++) {
                this.Parameters[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.Options.Count; j < count2; j++) {
                this.Options[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
