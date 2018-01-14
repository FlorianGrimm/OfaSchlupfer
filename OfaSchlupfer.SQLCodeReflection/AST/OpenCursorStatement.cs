#pragma warning disable SA1402
#pragma warning disable SA1600
#pragma warning disable SA1649

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class OpenCursorStatement : CursorStatement {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
