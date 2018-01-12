using antlr;

namespace OfaSchlupfer.ScriptDom {
    internal class TableHintOptionsHelper : OptionsHelper<TableHintKind> {
        internal static readonly TableHintOptionsHelper Instance = new TableHintOptionsHelper();

        private TableHintOptionsHelper() {
            base.AddOptionMapping(TableHintKind.FastFirstRow, "FASTFIRSTROW", SqlVersionFlags.TSqlUnder110);
            base.AddOptionMapping(TableHintKind.HoldLock, TSqlTokenType.HoldLock, SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.NoLock, "NOLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.PagLock, "PAGLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadCommitted, "READCOMMITTED", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadPast, "READPAST", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadUncommitted, "READUNCOMMITTED", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.RepeatableRead, "REPEATABLEREAD", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.Rowlock, "ROWLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.Serializable, "SERIALIZABLE", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.TabLock, "TABLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.TabLockX, "TABLOCKX", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.UpdLock, "UPDLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.XLock, "XLOCK", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.NoExpand, "NOEXPAND", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.NoWait, "NOWAIT", SqlVersionFlags.TSqlAll);
            base.AddOptionMapping(TableHintKind.ReadCommittedLock, "READCOMMITTEDLOCK", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.KeepIdentity, "KEEPIDENTITY", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.KeepDefaults, "KEEPDEFAULTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.IgnoreConstraints, "IGNORE_CONSTRAINTS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.IgnoreTriggers, "IGNORE_TRIGGERS", SqlVersionFlags.TSql90AndAbove);
            base.AddOptionMapping(TableHintKind.ForceSeek, "FORCESEEK", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(TableHintKind.ForceScan, "FORCESCAN", SqlVersionFlags.TSql100AndAbove);
            base.AddOptionMapping(TableHintKind.Snapshot, "SNAPSHOT", SqlVersionFlags.TSql120AndAbove);
        }

        protected override TSqlParseErrorException GetMatchingException(IToken token) {
            return new TSqlParseErrorException(TSql80ParserBaseInternal.CreateParseError("SQL46022", token, TSqlParserResource.SQL46022Message, token.getText()));
        }
    }
}
