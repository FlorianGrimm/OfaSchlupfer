namespace OfaSchlupfer.ScriptDom {
    internal class ModifyFilegroupOptionsHelper : OptionsHelper<ModifyFileGroupOption> {
        internal static readonly ModifyFilegroupOptionsHelper Instance = new ModifyFilegroupOptionsHelper();

        private ModifyFilegroupOptionsHelper() {
            base.AddOptionMapping(ModifyFileGroupOption.ReadOnly, "READ_ONLY");
            base.AddOptionMapping(ModifyFileGroupOption.ReadOnlyOld, "READONLY");
            base.AddOptionMapping(ModifyFileGroupOption.ReadWrite, "READ_WRITE");
            base.AddOptionMapping(ModifyFileGroupOption.ReadWriteOld, "READWRITE");
            base.AddOptionMapping(ModifyFileGroupOption.AutogrowAllFiles, "AUTOGROW_ALL_FILES", SqlVersionFlags.TSql130AndAbove);
            base.AddOptionMapping(ModifyFileGroupOption.AutogrowSingleFile, "AUTOGROW_SINGLE_FILE", SqlVersionFlags.TSql130AndAbove);
        }
    }
}
