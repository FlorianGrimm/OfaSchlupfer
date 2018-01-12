using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ConvertCall : PrimaryExpression {
        private DataTypeReference _dataType;

        private ScalarExpression _parameter;

        private ScalarExpression _style;

        public DataTypeReference DataType {
            get {
                return this._dataType;
            }
            set {
                base.UpdateTokenInfo(value);
                this._dataType = value;
            }
        }

        public ScalarExpression Parameter {
            get {
                return this._parameter;
            }
            set {
                base.UpdateTokenInfo(value);
                this._parameter = value;
            }
        }

        public ScalarExpression Style {
            get {
                return this._style;
            }
            set {
                base.UpdateTokenInfo(value);
                this._style = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.DataType?.Accept(visitor);
            this.Parameter?.Accept(visitor);
            this.Style?.Accept(visitor);
        }
    }
}
