using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class UserOptionHelper : OptionsHelper<PrincipalOptionKind> {
        internal static readonly UserOptionHelper Instance = new UserOptionHelper();

        private UserOptionHelper() {
            base.AddOptionMapping(PrincipalOptionKind.DefaultSchema, "DEFAULT_SCHEMA");
            base.AddOptionMapping(PrincipalOptionKind.DefaultLanguage, "DEFAULT_LANGUAGE");
            base.AddOptionMapping(PrincipalOptionKind.Name, "NAME");
            base.AddOptionMapping(PrincipalOptionKind.Login, "LOGIN");
            base.AddOptionMapping(PrincipalOptionKind.Type, "TYPE");
            base.AddOptionMapping(PrincipalOptionKind.Sid, "SID");
        }
    }
}
