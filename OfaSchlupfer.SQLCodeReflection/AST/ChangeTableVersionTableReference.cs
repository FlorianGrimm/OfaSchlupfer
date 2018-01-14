#pragma warning disable SA1600 // Elements must be documented
namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ChangeTableVersionTableReference : TableReferenceWithAliasAndColumns {
        private SchemaObjectName _target;

        private List<Identifier> _primaryKeyColumns = new List<Identifier>();

        private List<ScalarExpression> _primaryKeyValues = new List<ScalarExpression>();

        public SchemaObjectName Target {
            get {
                return this._target;
            }

            set {
                this.UpdateTokenInfo(value);
                this._target = value;
            }
        }

        public List<Identifier> PrimaryKeyColumns {
            get {
                return this._primaryKeyColumns;
            }
        }

        public List<ScalarExpression> PrimaryKeyValues {
            get {
                return this._primaryKeyValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Target?.Accept(visitor);
            for (int i = 0, count = this.PrimaryKeyColumns.Count; i < count; i++) {
                this.PrimaryKeyColumns[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = this.PrimaryKeyValues.Count; j < count2; j++) {
                this.PrimaryKeyValues[j].Accept(visitor);
            }
        }
    }
}
