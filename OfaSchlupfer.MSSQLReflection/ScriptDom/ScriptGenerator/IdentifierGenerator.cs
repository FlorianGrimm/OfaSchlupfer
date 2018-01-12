namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    internal sealed class IdentifierGenerator : TokenGenerator {
        private string _identifier;

        public IdentifierGenerator(string identifier)
            : this(identifier, false) {
        }

        public IdentifierGenerator(string identifier, bool appendSpace)
            : base(appendSpace) {
            this._identifier = identifier;
        }

        public override void Generate(ScriptWriter writer) {
            writer.AddIdentifierWithCasing(this._identifier);
            base.AppendSpaceIfRequired(writer);
        }
    }
}
