using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class RaiseErrorOptionsHelper : OptionsHelper<RaiseErrorOptions> {
        internal static readonly RaiseErrorOptionsHelper Instance = new RaiseErrorOptionsHelper();

        private RaiseErrorOptionsHelper() {
            base.AddOptionMapping(RaiseErrorOptions.Log, "LOG");
            base.AddOptionMapping(RaiseErrorOptions.NoWait, "NOWAIT");
            base.AddOptionMapping(RaiseErrorOptions.SetError, "SETERROR");
        }
    }
}
