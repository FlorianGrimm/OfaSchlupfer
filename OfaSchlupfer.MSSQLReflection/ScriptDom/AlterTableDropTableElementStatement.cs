namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableDropTableElementStatement : AlterTableStatement {
        private List<AlterTableDropTableElement> _alterTableDropTableElements = new List<AlterTableDropTableElement>();

        public List<AlterTableDropTableElement> AlterTableDropTableElements {
            get {
                return this._alterTableDropTableElements;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            for (int i = 0, count = this.AlterTableDropTableElements.Count; i < count; i++) {
                this.AlterTableDropTableElements[i].Accept(visitor);
            }
        }
    }
}
