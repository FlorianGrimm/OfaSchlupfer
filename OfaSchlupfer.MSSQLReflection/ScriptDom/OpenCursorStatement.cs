using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OpenCursorStatement : CursorStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
