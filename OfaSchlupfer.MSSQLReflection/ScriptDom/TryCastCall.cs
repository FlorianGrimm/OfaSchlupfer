using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TryCastCall : PrimaryExpression {
        private DataTypeReference _dataType;

        private ScalarExpression _parameter;

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }

            set {
                this.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public ScalarExpression Parameter {
            get {
                return this._parameter;
            }

            set {
                this.UpdateTokenInfo(value);
                this._parameter = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
        }
    }
}
