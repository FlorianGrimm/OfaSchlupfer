namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterTableChangeTrackingModificationStatement : AlterTableStatement {
        private bool _isEnable;

        private OptionState _trackColumnsUpdated;

        public bool IsEnable {
            get {
                return this._isEnable;
            }

            set {
                this._isEnable = value;
            }
        }

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
            if (base.SchemaObjectName != null) {
                base.SchemaObjectName.Accept(visitor);
            }
        }
    }
}
