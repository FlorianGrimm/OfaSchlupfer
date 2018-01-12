using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SpatialIndexRegularOption : SpatialIndexOption {
        private IndexOption _option;

        public IndexOption Option {
            get {
                return this._option;
            }
            set {
                base.UpdateTokenInfo(value);
                this._option = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Option?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
