using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MoveRestoreOption : RestoreOption {
        private ValueExpression _logicalFileName;

        private ValueExpression _oSFileName;

        public ValueExpression LogicalFileName {
            get {
                return this._logicalFileName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._logicalFileName = value;
            }
        }

        public ValueExpression OSFileName {
            get {
                return this._oSFileName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._oSFileName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LogicalFileName?.Accept(visitor);
            this.OSFileName?.Accept(visitor);
        }
    }
}
