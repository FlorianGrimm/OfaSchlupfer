using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UpdateStatement : DataModificationStatement {
        private UpdateSpecification _updateSpecification;

        public UpdateSpecification UpdateSpecification {
            get {
                return this._updateSpecification;
            }
            set {
                base.UpdateTokenInfo(value);
                this._updateSpecification = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.UpdateSpecification?.Accept(visitor);
        }
    }
}
