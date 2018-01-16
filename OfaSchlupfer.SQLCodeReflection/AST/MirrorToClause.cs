namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class MirrorToClause : TSqlFragment {
        public List<DeviceInfo> Devices { get; } = new List<DeviceInfo>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Devices.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
