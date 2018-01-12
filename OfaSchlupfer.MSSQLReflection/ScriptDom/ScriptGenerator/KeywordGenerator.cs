namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    internal sealed class KeywordGenerator : TokenGenerator {
        private TSqlTokenType _keywordId;

        public KeywordGenerator(TSqlTokenType keywordId)
            : this(keywordId, false) {
        }

        public KeywordGenerator(TSqlTokenType keywordId, bool appendSpace)
            : base(appendSpace) {
            this._keywordId = keywordId;
        }

        public override void Generate(ScriptWriter writer) {
            writer.AddKeyword(this._keywordId);
            base.AppendSpaceIfRequired(writer);
        }
    }
}
