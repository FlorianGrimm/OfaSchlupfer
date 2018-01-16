namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class BulkOpenRowset : TableReferenceWithAliasAndColumns {
        private StringLiteral _dataFile;

        public StringLiteral DataFile {
            get {
                return this._dataFile;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataFile = value;
            }
        }

        public List<BulkInsertOption> Options { get; } = new List<BulkInsertOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataFile?.Accept(visitor);
            this.Options.Accept(visitor);
        }
    }
}
