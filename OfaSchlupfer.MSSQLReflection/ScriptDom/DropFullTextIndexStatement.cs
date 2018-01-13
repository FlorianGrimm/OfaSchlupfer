namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropFullTextIndexStatement : TSqlStatement {
        private SchemaObjectName _tableName;

        public SchemaObjectName TableName {
            get {
                return this._tableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TableName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
