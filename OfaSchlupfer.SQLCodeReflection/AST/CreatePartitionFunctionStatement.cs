namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CreatePartitionFunctionStatement : TSqlStatement {
        private Identifier _name;

        private PartitionParameterType _parameterType;

        private PartitionFunctionRange _range;

        private List<ScalarExpression> _boundaryValues = new List<ScalarExpression>();

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

        public List<ScalarExpression> BoundaryValues {
            get {
                return this._boundaryValues;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.Name != null) {
                this.Name.Accept(visitor);
            }
            if (this.ParameterType != null) {
                this.ParameterType.Accept(visitor);
            }
            int i = 0;
            for (int count = this.BoundaryValues.Count; i < count; i++) {
                this.BoundaryValues[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
