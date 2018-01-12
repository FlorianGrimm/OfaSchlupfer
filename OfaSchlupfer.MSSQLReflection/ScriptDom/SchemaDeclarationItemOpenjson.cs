namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SchemaDeclarationItemOpenjson : SchemaDeclarationItem {
        public bool AsJson { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
