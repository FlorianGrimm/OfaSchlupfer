namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class HadrDatabaseOption : DatabaseOption {
        public HadrDatabaseOptionKind HadrOption { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
