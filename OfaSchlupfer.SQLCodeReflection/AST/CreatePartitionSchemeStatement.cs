namespace OfaSchlupfer.AST {
    using System.Collections.Generic;
    [System.Serializable]
    public sealed class CreatePartitionSchemeStatement : TSqlStatement {
        private Identifier _name;

        private Identifier _partitionFunction;


        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public Identifier PartitionFunction {
            get {
                return this._partitionFunction;
            }

            set {
                this.UpdateTokenInfo(value);
                this._partitionFunction = value;
            }
        }

        public bool IsAll { get; set; }

        public List<IdentifierOrValueExpression> FileGroups { get; } = new List<IdentifierOrValueExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.PartitionFunction?.Accept(visitor);
            this.FileGroups.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
