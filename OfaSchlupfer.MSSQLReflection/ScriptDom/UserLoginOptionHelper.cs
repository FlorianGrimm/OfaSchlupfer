using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class UserLoginOptionHelper : OptionsHelper<UserLoginOptionType> {
        internal static readonly UserLoginOptionHelper Instance = new UserLoginOptionHelper();

        private UserLoginOptionHelper() {
            base.AddOptionMapping(UserLoginOptionType.Certificate, "CERTIFICATE");
            base.AddOptionMapping(UserLoginOptionType.Login, "LOGIN");
        }
    }
}
