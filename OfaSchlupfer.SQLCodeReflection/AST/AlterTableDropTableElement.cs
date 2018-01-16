namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterTableDropTableElement : TSqlFragment {
        private TableElementType _tableElementType;

        private Identifier _name;

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

        public List<DropClusteredConstraintOption> DropClusteredConstraintOptions { get; } = new List<DropClusteredConstraintOption>();

        public bool IsIfExists { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.DropClusteredConstraintOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
