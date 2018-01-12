using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SelectFunctionReturnType : FunctionReturnType {
        private SelectStatement _selectStatement;

        public SelectStatement SelectStatement {
            get {
                return this._selectStatement;
            }

            set {
                this.UpdateTokenInfo(value);
                this._selectStatement = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SelectStatement?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
