namespace OfaSchlupfer.AST {
    [System.Serializable]
    public class TableHint : TSqlFragment {

        public TableHintKind HintKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
