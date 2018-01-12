using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MergeStatement : DataModificationStatement {
        private MergeSpecification _mergeSpecification;

        public MergeSpecification MergeSpecification {
            get {
                return this._mergeSpecification;
            }

            set {
                this.UpdateTokenInfo(value);
                this._mergeSpecification = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.MergeSpecification?.Accept(visitor);
        }
    }
}
