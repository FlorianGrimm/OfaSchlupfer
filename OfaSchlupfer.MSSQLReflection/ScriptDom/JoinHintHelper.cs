namespace OfaSchlupfer.ScriptDom {
    internal class JoinHintHelper : OptionsHelper<JoinHint> {
        internal static readonly JoinHintHelper Instance = new JoinHintHelper();

        private JoinHintHelper() {
            base.AddOptionMapping(JoinHint.Hash, "HASH", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(JoinHint.Loop, "LOOP", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(JoinHint.Merge, "MERGE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(JoinHint.Remote, "REMOTE", SqlVersionFlags.TSqlAll);
        }
    }
}
