using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PartitionSpecifier : TSqlFragment {
        private ScalarExpression _number;

        private bool _all;

        public ScalarExpression Number {
            get {
                return this._number;
            }
            set {
                base.UpdateTokenInfo(value);
                this._number = value;
            }
        }

        public bool All {
            get {
                return this._all;
            }
            set {
                this._all = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Number?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
