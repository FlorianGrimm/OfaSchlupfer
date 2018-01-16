namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableAlterIndexStatement : AlterTableStatement {
        private Identifier _indexIdentifier;

        private AlterIndexType _alterIndexType;

        public Identifier IndexIdentifier {
            get {
                return this._indexIdentifier;
            }

            set {
                this.UpdateTokenInfo(value);
                this._indexIdentifier = value;
            }
        }

        public AlterIndexType AlterIndexType {
            get {
                return this._alterIndexType;
            }

            set {
                this._alterIndexType = value;
            }
        }

        public List<IndexOption> IndexOptions { get; } = new List<IndexOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.IndexIdentifier?.Accept(visitor);
            this.IndexOptions.Accept(visitor);
        }
    }
}
