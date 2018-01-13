namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class DropAssemblyStatement : DropObjectsStatement {
        public bool WithNoDependents { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
