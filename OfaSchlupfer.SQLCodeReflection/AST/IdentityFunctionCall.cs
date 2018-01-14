namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class IdentityFunctionCall : ScalarExpression {
        private DataTypeReference _dataType;

        private ScalarExpression _seed;

        private ScalarExpression _increment;

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public ScalarExpression Seed {
            get {
                return this._seed;
            }

            set {
                this.UpdateTokenInfo(value);
                this._seed = value;
            }
        }

        public ScalarExpression Increment {
            get {
                return this._increment;
            }

            set {
                this.UpdateTokenInfo(value);
                this._increment = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DataType?.Accept(visitor);
            this.Seed?.Accept(visitor);
            this.Increment?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
