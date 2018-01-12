namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ResampleStatisticsOption : StatisticsOption {

        public List<StatisticsPartitionRange> Partitions { get; } = new List<StatisticsPartitionRange>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var partitions = this.Partitions;
            for (int i = 0, count = partitions.Count; i < count; i++) {
                partitions[i].Accept(visitor);
            }
        }
    }
}
