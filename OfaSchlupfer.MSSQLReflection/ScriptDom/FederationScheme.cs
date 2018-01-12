using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FederationScheme : TSqlFragment {
        private Identifier _distributionName;

        private Identifier _columnName;

        public Identifier DistributionName {
            get {
                return this._distributionName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._distributionName = value;
            }
        }

        public Identifier ColumnName {
            get {
                return this._columnName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._columnName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DistributionName?.Accept(visitor);
            this.ColumnName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
