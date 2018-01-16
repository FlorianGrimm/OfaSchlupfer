namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class DropIndexClause : DropIndexClauseBase {
        private Identifier _index;

        private SchemaObjectName _object;

        public Identifier Index {
            get {
                return this._index;
            }

            set {
                this.UpdateTokenInfo(value);
                this._index = value;
            }
        }

        public SchemaObjectName Object {
            get {
                return this._object;
            }

            set {
                this.UpdateTokenInfo(value);
                this._object = value;
            }
        }

        public List<IndexOption> Options { get; } = new List<IndexOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Index?.Accept(visitor);
            this.Object?.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
