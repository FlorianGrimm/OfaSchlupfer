using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class InsertSpecification : DataModificationSpecification {
        private InsertOption _insertOption;

        private InsertSource _insertSource;

        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        public InsertOption InsertOption {
            get {
                return this._insertOption;
            }

            set {
                this._insertOption = value;
            }
        }

        public InsertSource InsertSource {
            get {
                return this._insertSource;
            }

            set {
                this.UpdateTokenInfo(value);
                this._insertSource = value;
            }
        }

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.InsertSource?.Accept(visitor);
            for (int i = 0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
        }
    }
}
