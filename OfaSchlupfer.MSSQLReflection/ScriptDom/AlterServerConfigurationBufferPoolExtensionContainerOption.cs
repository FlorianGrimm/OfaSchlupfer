namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterServerConfigurationBufferPoolExtensionContainerOption : AlterServerConfigurationBufferPoolExtensionOption {
        public List<AlterServerConfigurationBufferPoolExtensionOption> Suboptions { get; } = new List<AlterServerConfigurationBufferPoolExtensionOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var suboptions = this.Suboptions;
            for (int i = 0, count = suboptions.Count; i < count; i++) {
                suboptions[i].Accept(visitor);
            }
        }
    }
}
