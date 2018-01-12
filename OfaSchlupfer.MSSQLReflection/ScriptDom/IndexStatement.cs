using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class IndexStatement : TSqlStatement {
        private Identifier _name;

        private SchemaObjectName _onName;

        private List<IndexOption> _indexOptions = new List<IndexOption>();

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SchemaObjectName OnName {
            get {
                return this._onName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._onName = value;
            }
        }

        public List<IndexOption> IndexOptions {
            get {
                return this._indexOptions;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.OnName?.Accept(visitor);
            for (int i=0, count = this.IndexOptions.Count; i < count; i++) {
                this.IndexOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
