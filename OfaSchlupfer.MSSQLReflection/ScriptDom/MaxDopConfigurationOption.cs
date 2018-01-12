namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public /**/ class MaxDopConfigurationOption : DatabaseConfigurationSetOption {
        public Literal Value { get; set; }

        public bool Primary { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
