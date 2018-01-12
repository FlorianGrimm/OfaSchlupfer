using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class PermissionSetOptionHelper : OptionsHelper<PermissionSetOption> {
        internal static readonly PermissionSetOptionHelper Instance = new PermissionSetOptionHelper();

        private PermissionSetOptionHelper() {
            base.AddOptionMapping(PermissionSetOption.Safe, "SAFE");
            base.AddOptionMapping(PermissionSetOption.ExternalAccess, "EXTERNAL_ACCESS");
            base.AddOptionMapping(PermissionSetOption.Unsafe, "UNSAFE");
        }
    }
}
