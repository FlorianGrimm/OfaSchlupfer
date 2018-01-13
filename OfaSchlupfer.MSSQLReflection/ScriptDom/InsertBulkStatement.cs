using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InsertBulkStatement : BulkInsertBase {
        private List<InsertBulkColumnDefinition> _columnDefinitions = new List<InsertBulkColumnDefinition>();

        public List<InsertBulkColumnDefinition> ColumnDefinitions {
            get {
                return this._columnDefinitions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.ColumnDefinitions.Count; i < count; i++) {
                this.ColumnDefinitions[i].Accept(visitor);
            }
        }
    }
}
