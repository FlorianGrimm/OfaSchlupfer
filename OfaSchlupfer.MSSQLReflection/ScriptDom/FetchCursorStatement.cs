using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FetchCursorStatement : CursorStatement {
        private FetchType _fetchType;

        private List<VariableReference> _intoVariables = new List<VariableReference>();

        public FetchType FetchType {
            get {
                return this._fetchType;
            }
            set {
                base.UpdateTokenInfo(value);
                this._fetchType = value;
            }
        }

        public List<VariableReference> IntoVariables {
            get {
                return this._intoVariables;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.FetchType?.Accept(visitor);
            for (int i=0, count = this.IntoVariables.Count; i < count; i++) {
                this.IntoVariables[i].Accept(visitor);
            }
        }
    }
}
