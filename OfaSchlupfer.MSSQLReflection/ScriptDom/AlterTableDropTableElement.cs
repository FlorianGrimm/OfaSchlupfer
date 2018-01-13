namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableDropTableElement : TSqlFragment {
        private TableElementType _tableElementType;

        private Identifier _name;

        private List<DropClusteredConstraintOption> _dropClusteredConstraintOptions = new List<DropClusteredConstraintOption>();

        private bool _isIfExists;

        public TableElementType TableElementType {
            get {
                return this._tableElementType;
            }

            set {
                this._tableElementType = value;
            }
        }

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<DropClusteredConstraintOption> DropClusteredConstraintOptions {
            get {
                return this._dropClusteredConstraintOptions;
            }
        }

        public bool IsIfExists {
            get {
                return this._isIfExists;
            }

            set {
                this._isIfExists = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            for (int i = 0, count = this.DropClusteredConstraintOptions.Count; i < count; i++) {
                this.DropClusteredConstraintOptions[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
