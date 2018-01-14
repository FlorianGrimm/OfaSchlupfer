namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class OdbcQualifiedJoinTableReference : TableReference {
        private TableReference _tableReference;

        public TableReference TableReference {
            get {
                return this._tableReference;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableReference = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TableReference?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
