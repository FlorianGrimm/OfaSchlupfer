namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class DatabaseConfigurationSetOption : TSqlFragment {
        public DatabaseConfigSetOptionKind OptionKind { get; set; }

        public Identifier GenericOptionKind { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) {
            if (visitor != null) {
                visitor.ExplicitVisit(this);
            }
        }
    }
}
