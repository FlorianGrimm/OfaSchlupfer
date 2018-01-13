namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RemoteDataArchiveDbServerSetting : RemoteDataArchiveDatabaseSetting {
        private StringLiteral _server;

        public StringLiteral Server {
            get {
                return this._server;
            }

            set {
                this._server = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
