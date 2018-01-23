namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class SchemaObjectNameSnippet : MultiPartIdentifier {
        public Identifier ServerIdentifier => this.ChooseIdentifier(4);

        public Identifier DatabaseIdentifier => this.ChooseIdentifier(3);

        public Identifier SchemaIdentifier => this.ChooseIdentifier(2);

        public Identifier BaseIdentifier => this.ChooseIdentifier(1);

        private Identifier ChooseIdentifier(int modifier) {
            int num = this.Identifiers.Count - modifier;
            if (num < 0) {
                return null;
            } else {
                return this.Identifiers[num];
            }
        }
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
