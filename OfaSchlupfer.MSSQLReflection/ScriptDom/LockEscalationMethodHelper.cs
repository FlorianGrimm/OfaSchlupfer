namespace OfaSchlupfer.ScriptDom {
    internal class LockEscalationMethodHelper : OptionsHelper<LockEscalationMethod> {
        public static LockEscalationMethodHelper Instance = new LockEscalationMethodHelper();

        private LockEscalationMethodHelper() {
            base.AddOptionMapping(LockEscalationMethod.Auto, "AUTO");
            base.AddOptionMapping(LockEscalationMethod.Disable, "DISABLE");
            base.AddOptionMapping(LockEscalationMethod.Table, TSqlTokenType.Table);
        }
    }
}
