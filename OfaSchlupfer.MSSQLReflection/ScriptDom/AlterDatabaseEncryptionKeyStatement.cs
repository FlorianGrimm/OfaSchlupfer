namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseEncryptionKeyStatement : DatabaseEncryptionKeyStatement {
        private bool _regenerate;

        public bool Regenerate {
            get {
                return this._regenerate;
            }

            set {
                this._regenerate = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
