namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterServerConfigurationDiagnosticsLogMaxSizeOption : AlterServerConfigurationDiagnosticsLogOption {
        public MemoryUnit SizeUnit { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
