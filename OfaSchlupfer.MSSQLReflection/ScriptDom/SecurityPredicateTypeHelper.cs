using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class SecurityPredicateTypeHelper : OptionsHelper<SecurityPredicateType> {
        internal static readonly SecurityPredicateTypeHelper Instance = new SecurityPredicateTypeHelper();

        private SecurityPredicateTypeHelper() {
            base.AddOptionMapping(SecurityPredicateType.Filter, "FILTER", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(SecurityPredicateType.Block, "BLOCK", SqlVersionFlags.TSql130AndAbove);
        }
    }
}
