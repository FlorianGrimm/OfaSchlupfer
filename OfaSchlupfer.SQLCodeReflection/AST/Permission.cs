using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class Permission : TSqlFragment {
        private List<Identifier> _identifiers = new List<Identifier>();

        private List<Identifier> _columns = new List<Identifier>();

        public List<Identifier> Identifiers {
            get {
                return this._identifiers;
            }
        }

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Identifiers.Count; i < count; i++) {
                this.Identifiers[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.Columns.Count; j < count2; j++) {
                this.Columns[j].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
