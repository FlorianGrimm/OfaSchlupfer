using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExternalTableShardedDistributionPolicy : ExternalTableDistributionPolicy {
        private Identifier _shardingColumn;

        public Identifier ShardingColumn {
            get {
                return this._shardingColumn;
            }

            set {
                this._shardingColumn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
