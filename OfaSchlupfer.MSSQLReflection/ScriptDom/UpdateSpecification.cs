using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UpdateSpecification : UpdateDeleteSpecificationBase {
        private List<SetClause> _setClauses = new List<SetClause>();

        public List<SetClause> SetClauses {
            get {
                return this._setClauses;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.SetClauses.Count; i < count; i++) {
                this.SetClauses[i].Accept(visitor);
            }
        }
    }
}
