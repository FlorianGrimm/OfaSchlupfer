using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class WaitForOptionHelper : OptionsHelper<WaitForOption> {
        internal static readonly WaitForOptionHelper Instance = new WaitForOptionHelper();

        private WaitForOptionHelper() {
            base.AddOptionMapping(WaitForOption.Delay, "DELAY");
            base.AddOptionMapping(WaitForOption.Time, "TIME");
        }
    }
}
