namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class FileDeclarationOption : TSqlFragment {
        public FileDeclarationOptionKind OptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
