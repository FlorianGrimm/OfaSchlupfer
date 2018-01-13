namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TSqlStatementSnippet : TSqlStatement {
        private string _script;

        public string Script {
            get {
                return this._script;
            }

            set {
                this._script = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
