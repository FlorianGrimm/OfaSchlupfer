namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class IndexStatement : TSqlStatement {
        private Identifier _name;

        private SchemaObjectName _onName;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SchemaObjectName OnName {
            get {
                return this._onName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._onName = value;
            }
        }

        public List<IndexOption> IndexOptions { get; } = new List<IndexOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.OnName?.Accept(visitor);
            this.IndexOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
