using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class BulkInsertBase : TSqlStatement {
        private SchemaObjectName _to;

        private List<BulkInsertOption> _options = new List<BulkInsertOption>();

        public SchemaObjectName To {
            get {
                return this._to;
            }

            set {
                this.UpdateTokenInfo(value);
                this._to = value;
            }
        }

        public List<BulkInsertOption> Options {
            get {
                return this._options;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.To?.Accept(visitor);
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
