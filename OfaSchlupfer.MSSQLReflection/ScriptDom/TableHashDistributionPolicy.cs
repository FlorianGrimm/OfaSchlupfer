using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TableHashDistributionPolicy : TableDistributionPolicy {
        private Identifier _distributionColumn;

        public Identifier DistributionColumn {
            get {
                return this._distributionColumn;
            }

            set {
                this._distributionColumn = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
