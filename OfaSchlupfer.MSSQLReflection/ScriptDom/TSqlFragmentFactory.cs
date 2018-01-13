namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    internal class TSqlFragmentFactory {
        private IList<TSqlParserToken> _tokenStream;

        public void SetTokenStream(IList<TSqlParserToken> tokenStream) {
            this._tokenStream = tokenStream;
        }

        public virtual FragmentType CreateFragment<FragmentType>() where FragmentType : TSqlFragment, new() {
            FragmentType result = new FragmentType();
            result.ScriptTokenStream = this._tokenStream;
            return result;
        }
    }
}
