using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ParseCall : PrimaryExpression {
        private ScalarExpression _stringValue;

        private DataTypeReference _dataType;

        private ScalarExpression _culture;

        public ScalarExpression StringValue {
            get {
                return this._stringValue;
            }
            set {
                base.UpdateTokenInfo(value);
                this._stringValue = value;
            }
        }

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }
            set {
                base.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public ScalarExpression Culture {
            get {
                return this._culture;
            }
            set {
                base.UpdateTokenInfo(value);
                this._culture = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.StringValue?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Culture?.Accept(visitor);
        }
    }
}
