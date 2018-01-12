using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ComputeClause : TSqlFragment {
        private List<ComputeFunction> _computeFunctions = new List<ComputeFunction>();

        private List<ScalarExpression> _byExpressions = new List<ScalarExpression>();

        public List<ComputeFunction> ComputeFunctions {
            get {
                return this._computeFunctions;
            }
        }

        public List<ScalarExpression> ByExpressions {
            get {
                return this._byExpressions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.ComputeFunctions.Count; i < count; i++) {
                this.ComputeFunctions[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.ByExpressions.Count; j < count2; j++) {
                this.ByExpressions[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
