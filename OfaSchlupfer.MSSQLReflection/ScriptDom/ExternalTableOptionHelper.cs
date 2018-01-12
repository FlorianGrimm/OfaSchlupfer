namespace OfaSchlupfer.ScriptDom {
    internal class ExternalTableOptionHelper : OptionsHelper<ExternalTableOptionKind> {
        internal static readonly ExternalTableOptionHelper Instance = new ExternalTableOptionHelper();

        private ExternalTableOptionHelper() {
            base.AddOptionMapping(ExternalTableOptionKind.Distribution, "DISTRIBUTION");
            base.AddOptionMapping(ExternalTableOptionKind.FileFormat, "FILE_FORMAT");
            base.AddOptionMapping(ExternalTableOptionKind.Location, "LOCATION");
            base.AddOptionMapping(ExternalTableOptionKind.RejectSampleValue, "REJECT_SAMPLE_VALUE");
            base.AddOptionMapping(ExternalTableOptionKind.RejectType, "REJECT_TYPE");
            base.AddOptionMapping(ExternalTableOptionKind.RejectValue, "REJECT_VALUE");
            base.AddOptionMapping(ExternalTableOptionKind.SchemaName, "SCHEMA_NAME");
            base.AddOptionMapping(ExternalTableOptionKind.ObjectName, "OBJECT_NAME");
        }
    }
}
