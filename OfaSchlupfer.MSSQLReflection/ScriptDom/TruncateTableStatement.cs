using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TruncateTableStatement : TSqlStatement {
        private SchemaObjectName _tableName;

        private List<CompressionPartitionRange> _partitionRanges = new List<CompressionPartitionRange>();

        public SchemaObjectName TableName {
            get {
                return this._tableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableName = value;
            }
        }

        public List<CompressionPartitionRange> PartitionRanges {
            get {
                return this._partitionRanges;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.TableName?.Accept(visitor);
            for (int i=0, count = this.PartitionRanges.Count; i < count; i++) {
                this.PartitionRanges[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
