using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    internal class PredicateSetOptionsHelper : OptionsHelper<SetOptions> {
        internal static readonly PredicateSetOptionsHelper Instance = new PredicateSetOptionsHelper();

        private PredicateSetOptionsHelper() {
            base.AddOptionMapping(SetOptions.QuotedIdentifier, "QUOTED_IDENTIFIER", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ConcatNullYieldsNull, "CONCAT_NULL_YIELDS_NULL", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.CursorCloseOnCommit, "CURSOR_CLOSE_ON_COMMIT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ArithAbort, "ARITHABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ArithIgnore, "ARITHIGNORE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.FmtOnly, "FMTONLY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.NoCount, "NOCOUNT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.NoExec, "NOEXEC", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.NumericRoundAbort, "NUMERIC_ROUNDABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ParseOnly, "PARSEONLY", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiDefaults, "ANSI_DEFAULTS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiNullDfltOff, "ANSI_NULL_DFLT_OFF", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiNullDfltOn, "ANSI_NULL_DFLT_ON", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiNulls, "ANSI_NULLS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiPadding, "ANSI_PADDING", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.AnsiWarnings, "ANSI_WARNINGS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ForcePlan, "FORCEPLAN", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ShowPlanAll, "SHOWPLAN_ALL", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ShowPlanText, "SHOWPLAN_TEXT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ShowPlanXml, "SHOWPLAN_XML", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.ImplicitTransactions, "IMPLICIT_TRANSACTIONS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.RemoteProcTransactions, "REMOTE_PROC_TRANSACTIONS", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.XactAbort, "XACT_ABORT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(SetOptions.DisableDefCnstChk, "DISABLE_DEF_CNST_CHK", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(SetOptions.NoBrowsetable, "NO_BROWSETABLE", SqlVersionFlags.TSqlAll);
        }
    }
}
