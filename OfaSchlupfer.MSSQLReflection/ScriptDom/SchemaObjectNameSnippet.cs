namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SchemaObjectNameSnippet : SchemaObjectName {
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
