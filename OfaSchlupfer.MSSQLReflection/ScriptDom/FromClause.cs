using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FromClause : TSqlFragment {
        private List<TableReference> _tableReferences = new List<TableReference>();

        public List<TableReference> TableReferences {
            get {
                return this._tableReferences;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.TableReferences.Count; i < count; i++) {
                this.TableReferences[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
