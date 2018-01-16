namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class TableHintsOptimizerHint : OptimizerHint {
        private SchemaObjectName _objectName;

        public SchemaObjectName ObjectName {
            get {
                return this._objectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._objectName = value;
            }
        }

        public List<TableHint> TableHints { get; } = new List<TableHint>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.ObjectName?.Accept(visitor);
            this.TableHints.Accept(visitor);
        }
    }
}
