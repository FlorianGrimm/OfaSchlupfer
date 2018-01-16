namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FileGroupOrPartitionScheme : TSqlFragment {
        private IdentifierOrValueExpression _name;

        public IdentifierOrValueExpression Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<Identifier> PartitionSchemeColumns { get; } = new List<Identifier>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.PartitionSchemeColumns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
