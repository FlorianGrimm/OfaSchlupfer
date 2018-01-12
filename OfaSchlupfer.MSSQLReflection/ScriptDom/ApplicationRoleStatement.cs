using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class ApplicationRoleStatement : TSqlStatement {
        private Identifier _name;

        private List<ApplicationRoleOption> _applicationRoleOptions = new List<ApplicationRoleOption>();

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ApplicationRoleOption> ApplicationRoleOptions {
            get {
                return this._applicationRoleOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.ApplicationRoleOptions.Count; i < count; i++) {
                this.ApplicationRoleOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
