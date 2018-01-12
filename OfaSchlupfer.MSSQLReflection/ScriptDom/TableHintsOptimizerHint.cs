namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TableHintsOptimizerHint : OptimizerHint {
        private SchemaObjectName _objectName;

        private List<TableHint> _tableHints = new List<TableHint>();

        public SchemaObjectName ObjectName {
            get {
                return this._objectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._objectName = value;
            }
        }

        public List<TableHint> TableHints {
            get {
                return this._tableHints;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ObjectName?.Accept(visitor);
            for (int i=0, count = this.TableHints.Count; i < count; i++) {
                this.TableHints[i].Accept(visitor);
            }
        }
    }
}
