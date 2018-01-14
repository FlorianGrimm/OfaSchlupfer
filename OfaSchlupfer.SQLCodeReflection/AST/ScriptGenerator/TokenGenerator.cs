namespace OfaSchlupfer.AST.ScriptGenerator {
    internal abstract class TokenGenerator {
        private bool _appendSpace;

        public TokenGenerator(bool appendSpace) {
            this._appendSpace = appendSpace;
        }

        protected void AppendSpaceIfRequired(ScriptWriter writer) {
            if (this._appendSpace) {
                writer.AddToken(ScriptGeneratorSupporter.CreateWhitespaceToken(1));
            }
        }

        public abstract void Generate(ScriptWriter writer);
    }
}
