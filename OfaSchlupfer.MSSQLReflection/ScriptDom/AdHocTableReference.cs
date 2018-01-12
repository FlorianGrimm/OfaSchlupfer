namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AdHocTableReference : TableReferenceWithAlias {
        private AdHocDataSource _dataSource;

        private SchemaObjectNameOrValueExpression _object;

        public AdHocDataSource DataSource {
            get {
                return this._dataSource;
            }
            set {
                base.UpdateTokenInfo(value);
                this._dataSource = value;
            }
        }

        public SchemaObjectNameOrValueExpression Object {
            get {
                return this._object;
            }
            set {
                base.UpdateTokenInfo(value);
                this._object = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataSource?.Accept(visitor);
            this.Object?.Accept(visitor);
        }
    }
}
