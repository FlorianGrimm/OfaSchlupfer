namespace OfaSchlupfer.ScriptDom {
    internal class JsonForClauseOptionsHelper : OptionsHelper<JsonForClauseOptions> {
        internal static readonly JsonForClauseOptionsHelper Instance = new JsonForClauseOptionsHelper();

        private JsonForClauseOptionsHelper() {
            base.AddOptionMapping(JsonForClauseOptions.Root, "ROOT");
            base.AddOptionMapping(JsonForClauseOptions.IncludeNullValues, "INCLUDE_NULL_VALUES");
            base.AddOptionMapping(JsonForClauseOptions.WithoutArrayWrapper, "WITHOUT_ARRAY_WRAPPER");
        }
    }
}
