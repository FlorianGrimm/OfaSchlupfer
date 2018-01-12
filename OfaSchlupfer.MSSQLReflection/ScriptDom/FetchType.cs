using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FetchType : TSqlFragment {
        private FetchOrientation _orientation;

        private ScalarExpression _rowOffset;

        public FetchOrientation Orientation {
            get {
                return this._orientation;
            }
            set {
                this._orientation = value;
            }
        }

        public ScalarExpression RowOffset {
            get {
                return this._rowOffset;
            }
            set {
                base.UpdateTokenInfo(value);
                this._rowOffset = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.RowOffset?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
