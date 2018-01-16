namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreatePartitionFunctionStatement : TSqlStatement {
        private Identifier _name;

        private PartitionParameterType _parameterType;

        private PartitionFunctionRange _range;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public PartitionParameterType ParameterType {
            get {
                return this._parameterType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameterType = value;
            }
        }

        public PartitionFunctionRange Range {
            get {
                return this._range;
            }

            set {
                this._range = value;
            }
        }

        public List<ScalarExpression> BoundaryValues { get; } = new List<ScalarExpression>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ParameterType?.Accept(visitor);
            this.BoundaryValues.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
