namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class AlterDatabaseStatement : TSqlStatement {
        private Identifier _databaseName;

        public Identifier DatabaseName {
            get {
                return this._databaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public bool UseCurrent { get; set; }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DatabaseName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
