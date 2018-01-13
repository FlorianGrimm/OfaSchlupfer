namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RemoteDataArchiveDbCredentialSetting : RemoteDataArchiveDatabaseSetting {
        private Identifier _credential;

        public Identifier Credential {
            get {
                return this._credential;
            }

            set {
                this._credential = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
