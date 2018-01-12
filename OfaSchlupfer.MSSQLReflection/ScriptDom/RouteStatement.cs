using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class RouteStatement : TSqlStatement {
        private Identifier _name;

        private List<RouteOption> _routeOptions = new List<RouteOption>();

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<RouteOption> RouteOptions {
            get {
                return this._routeOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i=0, count = this.RouteOptions.Count; i < count; i++) {
                this.RouteOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
