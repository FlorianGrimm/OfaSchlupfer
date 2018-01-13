namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class AlterDatabaseStatement : TSqlStatement {
        private Identifier _databaseName;

        private bool _useCurrent;

        public Identifier DatabaseName {
            get {
                return this._databaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public bool UseCurrent {
            get {
                return this._useCurrent;
            }

            set {
                this._useCurrent = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DatabaseName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
