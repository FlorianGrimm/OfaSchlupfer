namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableAlterIndexStatement : AlterTableStatement {
        private Identifier _indexIdentifier;

        private AlterIndexType _alterIndexType;

        private List<IndexOption> _indexOptions = new List<IndexOption>();

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

        public List<IndexOption> IndexOptions {
            get {
                return this._indexOptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
            this.IndexIdentifier?.Accept(visitor);
            for (int i = 0, count = this.IndexOptions.Count; i < count; i++) {
                this.IndexOptions[i].Accept(visitor);
            }
        }
    }
}
