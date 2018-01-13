namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseScopedConfigurationClearStatement : AlterDatabaseScopedConfigurationStatement {
        private DatabaseConfigurationClearOption _option;

        public DatabaseConfigurationClearOption Option {
            get {
                return this._option;
            }

            set {
                this.UpdateTokenInfo(value);
                this._option = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Option?.Accept(visitor);
        }
    }
}
