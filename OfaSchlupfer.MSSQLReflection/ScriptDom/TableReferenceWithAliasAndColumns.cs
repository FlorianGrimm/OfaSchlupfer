using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class TableReferenceWithAliasAndColumns : TableReferenceWithAlias {
        private List<Identifier> _columns = new List<Identifier>();

        public List<Identifier> Columns {
            get {
                return this._columns;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
        }
    }
}
