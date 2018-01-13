namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AlterDatabaseScopedConfigurationStatement : TSqlStatement {
        private bool _secondary;

        public bool Secondary {
            get {
                return this._secondary;
            }

            set {
                this._secondary = value;
            }
        }
    }
}
