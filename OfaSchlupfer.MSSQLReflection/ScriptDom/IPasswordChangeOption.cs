namespace OfaSchlupfer.ScriptDom {

    internal interface IPasswordChangeOption {
        Literal EncryptionPassword {
            get;
            set;
        }

        Literal DecryptionPassword {
            get;
            set;
        }
    }
}
