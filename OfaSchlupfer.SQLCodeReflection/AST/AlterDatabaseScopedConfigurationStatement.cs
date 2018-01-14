namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class AlterDatabaseScopedConfigurationStatement : TSqlStatement {
        public bool Secondary { get; set; }
    }
}
