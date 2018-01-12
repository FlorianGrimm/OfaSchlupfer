namespace OfaSchlupfer.ScriptDom {
    internal class ExternalFileFormatOptionHelper : OptionsHelper<ExternalFileFormatOptionKind> {
        internal static readonly ExternalFileFormatOptionHelper Instance = new ExternalFileFormatOptionHelper();

        private ExternalFileFormatOptionHelper() {
            base.AddOptionMapping(ExternalFileFormatOptionKind.SerDeMethod, "SERDE_METHOD");
            base.AddOptionMapping(ExternalFileFormatOptionKind.FormatOptions, "FORMAT_OPTIONS");
            base.AddOptionMapping(ExternalFileFormatOptionKind.FieldTerminator, "FIELD_TERMINATOR");
            base.AddOptionMapping(ExternalFileFormatOptionKind.StringDelimiter, "STRING_DELIMITER");
            base.AddOptionMapping(ExternalFileFormatOptionKind.DateFormat, "DATE_FORMAT");
            base.AddOptionMapping(ExternalFileFormatOptionKind.UseTypeDefault, "USE_TYPE_DEFAULT");
            base.AddOptionMapping(ExternalFileFormatOptionKind.DataCompression, "DATA_COMPRESSION");
        }
    }
}
