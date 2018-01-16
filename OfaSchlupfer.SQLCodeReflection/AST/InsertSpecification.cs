namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class InsertSpecification : DataModificationSpecification {
        private InsertOption _insertOption;

        private InsertSource _insertSource;

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

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.InsertSource?.Accept(visitor);
            this.Columns.Accept(visitor);
        }
    }
}
