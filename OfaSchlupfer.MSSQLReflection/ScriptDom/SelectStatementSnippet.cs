using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SelectStatementSnippet : SelectStatement {
        public string Script { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
