using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class AtomicBlockOptionHelper : OptionsHelper<AtomicBlockOptionKind> {
        internal static readonly AtomicBlockOptionHelper Instance = new AtomicBlockOptionHelper();

        private AtomicBlockOptionHelper() {
            base.AddOptionMapping(AtomicBlockOptionKind.DateFirst, "DATEFIRST", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.DateFormat, "DATEFORMAT", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.DelayedDurability, "DELAYED_DURABILITY", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.IsolationLevel, "TRANSACTION ISOLATION LEVEL", SqlVersionFlags.TSql120AndAbove);
            base.AddOptionMapping(AtomicBlockOptionKind.Language, "LANGUAGE", SqlVersionFlags.TSql120AndAbove);
        }
    }
}
