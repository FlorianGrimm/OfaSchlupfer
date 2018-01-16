namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class BulkInsertBase : TSqlStatement {
        private SchemaObjectName _to;

        public SchemaObjectName To {
            get {
                return this._to;
            }

            set {
                this.UpdateTokenInfo(value);
                this._to = value;
            }
        }

        public List<BulkInsertOption> Options { get; } = new List<BulkInsertOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.To?.Accept(visitor);
            this.Options.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
