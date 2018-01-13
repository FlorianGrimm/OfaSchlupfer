namespace OfaSchlupfer.ScriptDom {
    [System.Flags]
    internal enum ExpressionFlags {
        None = 0,
        ScalarSubqueriesDisallowed = 1,
        MatchClauseAllowed = 2
    }
}
