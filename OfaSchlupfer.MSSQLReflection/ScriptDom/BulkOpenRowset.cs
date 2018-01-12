using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BulkOpenRowset : TableReferenceWithAliasAndColumns {
        private StringLiteral _dataFile;

        private List<BulkInsertOption> _options = new List<BulkInsertOption>();

        public StringLiteral DataFile {
            get {
                return this._dataFile;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataFile = value;
            }
        }

        public List<BulkInsertOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataFile?.Accept(visitor);
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
        }
    }
}
