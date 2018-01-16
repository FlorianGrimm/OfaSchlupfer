namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreateFullTextIndexStatement : TSqlStatement {
        private SchemaObjectName _onName;

        private Identifier _keyIndexName;

        private FullTextCatalogAndFileGroup _catalogAndFileGroup;

        public SchemaObjectName OnName {
            get {
                return this._onName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onName = value;
            }
        }

        public List<FullTextIndexColumn> FullTextIndexColumns { get; } = new List<FullTextIndexColumn>();

        public Identifier KeyIndexName {
            get {
                return this._keyIndexName;
            }
            set {
                this.UpdateTokenInfo(value);
                this._keyIndexName = value;
            }
        }

        public FullTextCatalogAndFileGroup CatalogAndFileGroup {
            get {
                return this._catalogAndFileGroup;
            }
            set {
                this.UpdateTokenInfo(value);
                this._catalogAndFileGroup = value;
            }
        }

        public List<FullTextIndexOption> Options { get; } = new List<FullTextIndexOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.OnName?.Accept(visitor);
            this.FullTextIndexColumns.Accept(visitor);
            this.KeyIndexName?.Accept(visitor);
            this.CatalogAndFileGroup?.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
