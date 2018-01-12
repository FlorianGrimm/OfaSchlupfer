namespace OfaSchlupfer.ScriptDom {
    internal class MessageValidationMethodsHelper : OptionsHelper<MessageValidationMethod> {
        internal static readonly MessageValidationMethodsHelper Instance = new MessageValidationMethodsHelper();

        private MessageValidationMethodsHelper() {
            base.AddOptionMapping(MessageValidationMethod.None, "NONE");
            base.AddOptionMapping(MessageValidationMethod.Empty, "EMPTY");
            base.AddOptionMapping(MessageValidationMethod.WellFormedXml, "WELL_FORMED_XML");
            base.AddOptionMapping(MessageValidationMethod.ValidXml, "VALID_XML");
        }
    }
}
