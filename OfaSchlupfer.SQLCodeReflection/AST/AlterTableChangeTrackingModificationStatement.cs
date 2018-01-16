namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class AlterTableChangeTrackingModificationStatement : AlterTableStatement {
        private OptionState _trackColumnsUpdated;

        public bool IsEnable { get; set; }

        public OptionState TrackColumnsUpdated {
            get {
                return this._trackColumnsUpdated;
            }

            set {
                this._trackColumnsUpdated = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
        }
    }
}
